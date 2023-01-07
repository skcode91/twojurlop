import {
  Button,
  Collapse,
  IconButton,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
  TextField,
  Typography,
} from "@mui/material";
import React, { useContext, useState } from "react";
import { getDisplayedDate } from "src/common/helpers/dateHelper";
import { VacationRequestListProps } from "./VacationRequestsListProps";
import plLocale from "date-fns/locale/pl";
import DeleteIcon from "@mui/icons-material/Delete";
import { getVacationRequestStatusName } from "src/common/helpers/translationHelper";
import { UserContext } from "src/common/contexts/UserContext";
import { VacationRequestStatus } from "src/common/enums/VacationRequestStatus";
import { Roles } from "src/common/enums/Roles";
import CheckIcon from "@mui/icons-material/Check";
import ClearIcon from "@mui/icons-material/Clear";
import { Stack } from "@mui/system";
import { HandleVacationRequestRequest } from "src/common/models/api/requests/HandleVacationRequestRequest";
import { VacationRequestDto } from "src/common/models/dto/VacationRequestDto";
import router from "next/router";
import { getPageUrl } from "src/common/helpers/routingHelper";
import { Pages } from "src/common/enums/Pages";

const VacationRequestsList = (props: VacationRequestListProps) => {
  const {
    vacationRequests,
    handleDelete,
    year,
    setYear,
    handleVacationRequest,
  } = props;
  const userContext = useContext(UserContext);
  const userId = userContext.user?.userId;
  const [isEditYearVisible, setIsEditYearVisible] = useState(false);
  const userRole = userContext.user ? userContext.user.role : Roles.User;
  console.log(userRole);

  const [inputVal, setInputVal] = useState<number>(year);

  const handleChangeYear = (e: HTMLInputElement | HTMLTextAreaElement) => {
    const val = e.value;
    if (!isNaN(+val)) {
      setInputVal(parseInt(val));
    }
  };

  const acceptYear = () => {
    setYear(inputVal);
    setIsEditYearVisible(false);
  };

  const handleRequest = (reqId: number, accepted: boolean) => {
    if (!userId) {
      router.push(getPageUrl(Pages.signIn));
      return;
    }
    const request: HandleVacationRequestRequest = {
      userId: userId,
      vacationRequestId: reqId,
      newRequestStatus: accepted
        ? VacationRequestStatus.Accepted
        : VacationRequestStatus.Declined,
    };
    handleVacationRequest(request);
  };

  return (
    <div>
      <Typography variant="h6">Lista próśb o urlop</Typography>
      <Stack display="flex" direction="row" padding="24px 0" gap="24px">
        <Typography variant="h6">Wybrany rok: {year}</Typography>
        <Button
          variant="contained"
          onClick={() => setIsEditYearVisible(!isEditYearVisible)}
        >
          Zmień
        </Button>
      </Stack>
      <Collapse in={isEditYearVisible}>
        <Stack display="flex" direction="column" padding="24px 0" gap="24px">
          <TextField
            value={inputVal}
            onChange={(e) => handleChangeYear(e.target)}
          />
          <Button variant="contained" onClick={() => acceptYear()}>
            Zastosuj
          </Button>
        </Stack>
      </Collapse>
      {vacationRequests ? (
        <Paper sx={{ background: "#1dcaff" }} elevation={12}>
          <Table
            sx={{ minWidth: 650, padding: "24px 0" }}
            aria-label="simple table"
          >
            <TableHead>
              <TableRow>
                <TableCell>Id</TableCell>
                <TableCell>Id pracownika</TableCell>
                <TableCell>Pełna nazwa</TableCell>
                <TableCell>Początek</TableCell>
                <TableCell>Koniec</TableCell>
                <TableCell>Status</TableCell>
                <TableCell>Akcje</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {vacationRequests.map((row) => (
                <TableRow
                  key={row.id}
                  sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
                >
                  <TableCell>{row.id}</TableCell>
                  <TableCell>{row.userId}</TableCell>
                  <TableCell>{row.userFullName}</TableCell>
                  <TableCell>
                    {getDisplayedDate(new Date(row.startDate), plLocale)}
                  </TableCell>
                  <TableCell>
                    {getDisplayedDate(new Date(row.endDate), plLocale)}
                  </TableCell>
                  <TableCell>
                    {getVacationRequestStatusName(row.statusId)}
                  </TableCell>
                  <TableCell>
                    {row.statusId === VacationRequestStatus.Active &&
                      row.userId === userId && (
                        <IconButton onClick={() => handleDelete(row)}>
                          <DeleteIcon />
                        </IconButton>
                      )}
                    {row.statusId === VacationRequestStatus.Active &&
                      userRole !== Roles.User &&
                      row.userId !== userId && (
                        <Stack display="flex" direction="row">
                          <IconButton
                            onClick={() => handleRequest(row.id, true)}
                          >
                            <CheckIcon />
                          </IconButton>
                          <IconButton
                            onClick={() => handleRequest(row.id, false)}
                          >
                            <ClearIcon />
                          </IconButton>
                        </Stack>
                      )}
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </Paper>
      ) : (
        <Typography variant="body2">Ładowanie</Typography>
      )}
    </div>
  );
};

export default VacationRequestsList;
