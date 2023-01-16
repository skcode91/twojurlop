import { Button, Collapse, TextField, Typography } from "@mui/material";
import React, { useCallback, useContext, useMemo, useState } from "react";
import { CvrFormContainer } from "./CreateVacationRequestStyles";
import { AdapterDateFns } from "@mui/x-date-pickers/AdapterDateFns";
import { LocalizationProvider } from "@mui/x-date-pickers";
import { DesktopDatePicker } from "@mui/x-date-pickers";
import plLocale from "date-fns/locale/pl";
import { addDays } from "date-fns";
import { formatDistance } from "date-fns";
import { SendVacationRequest } from "src/common/models/api/requests/SendVacationRequestRequest";
import { UserContext } from "src/common/contexts/UserContext";
import { CreateVacationRequestProps } from "./CreateVacationRequestProps";
import { Stack } from "@mui/system";

const CreateVacationRequest = (props: CreateVacationRequestProps) => {
  const { handleSendVacationRequest } = props;
  const [isFormVisible, setIsFormVisible] = useState(false);
  const oneDay = 1000 * 3600 * 24;
  const userContext = useContext(UserContext);
  const userId = userContext.user?.userId;
  const [customNumberOfDays, setCustomNumberOfDays] = useState<number>(0);

  const [startDate, setStartDate] = useState<Date | null>(new Date());
  const [endDate, setEndDate] = useState<Date | null>(new Date());
  console.log(customNumberOfDays);

  const daysCount = useMemo(() => {
    const start = startDate ?? new Date();
    const end = endDate ?? new Date();

    const distance = end.getTime() - start.getTime();

    if (distance < oneDay) {
      return "dzień";
    }
    const fixedEnd = endDate ? new Date(endDate) : new Date();
    fixedEnd.setHours(fixedEnd.getHours() + 24);
    return formatDistance(startDate ?? new Date(), fixedEnd, {
      includeSeconds: false,
      locale: plLocale,
      addSuffix: false,
    });
  }, [endDate, oneDay, startDate]);

  const maxEndDate = useMemo(
    () =>
      startDate ? new Date(addDays(startDate, 26)) : addDays(new Date(), 26),
    [startDate]
  );

  const handleChangeStartDate = (date: Date | null) => {
    setStartDate(date);
    if (date && endDate && date > endDate) setEndDate(date);
  };

  const handleChangeEndDate = (date: Date | null) => {
    date && date.setHours(date.getHours() + 1);
    setEndDate(date);
    if (startDate && date && date < startDate) setStartDate(date);
  };

  if (endDate && endDate.getTime() > maxEndDate.getTime())
    setEndDate(maxEndDate);

  const isInSameYear = useMemo(
    () =>
      startDate && endDate && startDate.getFullYear() === endDate.getFullYear(),
    [endDate, startDate]
  );

  const isFormValid = useMemo(
    () => daysCount !== "0 dni" && isInSameYear,
    [daysCount, isInSameYear]
  );

  const sendVacationRequest = useCallback(async () => {
    if (!startDate || !endDate || !userId) return false;
    const daysCount = Math.round(
      (endDate.getTime() - startDate.getTime()) / (1000 * 60 * 60 * 24)
    );
    const fixedDaysCount =
      customNumberOfDays > 0 ? customNumberOfDays : daysCount + 1;

    const request: SendVacationRequest = {
      userId: userId,
      startDate: startDate,
      endDate:
        endDate > startDate
          ? endDate
          : new Date(startDate.setHours(startDate.getHours() + 1)),
      daysCount: fixedDaysCount,
    };

    await handleSendVacationRequest(request);
    setIsFormVisible(false);
  }, [
    customNumberOfDays,
    endDate,
    handleSendVacationRequest,
    startDate,
    userId,
  ]);

  return (
    <div>
      <Button
        variant="contained"
        onClick={() => setIsFormVisible(!isFormVisible)}
      >
        Tworzenie prośby
      </Button>
      <Collapse in={isFormVisible}>
        <CvrFormContainer elevation={12}>
          <LocalizationProvider
            dateAdapter={AdapterDateFns}
            adapterLocale={plLocale}
          >
            <div>
              <Typography variant="h6">Początek</Typography>
              <DesktopDatePicker
                value={startDate}
                minDate={new Date()}
                onChange={handleChangeStartDate}
                renderInput={(params) => <TextField {...params} />}
              />
            </div>

            <div>
              <Typography variant="h6">Koniec</Typography>
              <DesktopDatePicker
                minDate={startDate ?? new Date()}
                maxDate={maxEndDate}
                value={endDate}
                onChange={handleChangeEndDate}
                renderInput={(params) => <TextField {...params} />}
              />
            </div>
          </LocalizationProvider>
          <div>
            <Typography variant="h6">Liczba dni</Typography>
            {customNumberOfDays > 0
              ? customNumberOfDays.toString() + " dni"
              : daysCount}
          </div>
          <Stack display="flex" direction="column">
            <Typography variant="h6">Własna liczba dni</Typography>
            <Typography variant="body2">
              (W przypadku świąt lub weekendów)
            </Typography>
          </Stack>

          <TextField
            value={customNumberOfDays > 0 ? customNumberOfDays : ""}
            onChange={(e) => setCustomNumberOfDays(Number(e.target.value))}
          />
          <div>
            {!isInSameYear && (
              <Typography color="error" variant="body2">
                Daty muszą obejmować ten sam rok!
              </Typography>
            )}
            <Button
              onClick={() => sendVacationRequest()}
              disabled={!isFormValid}
              variant="contained"
            >
              Wyślij prośbę o urlop
            </Button>
          </div>
        </CvrFormContainer>
      </Collapse>
    </div>
  );
};

export default CreateVacationRequest;
