import { Button, Collapse, Paper, TextField, Typography } from "@mui/material";
import { Stack } from "@mui/system";
import React, { useState } from "react";
import { CaItem, CaMainContainer } from "./CreateAccountStyles";
import { AdapterDateFns } from "@mui/x-date-pickers/AdapterDateFns";
import { LocalizationProvider } from "@mui/x-date-pickers";
import { DesktopDatePicker } from "@mui/x-date-pickers";
import plLocale from "date-fns/locale/pl";

const CreateAccount = () => {
  const [isFormVisible, setIsFormVisible] = useState(false);

  const [hiringDate, setHiringDate] = useState<Date>(new Date());
  const maxHiringDate = new Date();

  const handleChangeHiringDate = (date: Date | null) => {
    if (date) setHiringDate(date);
  };

  return (
    <Stack display="flex" component="form">
      <div>
        <Button
          onClick={() => setIsFormVisible(!isFormVisible)}
          sx={{ marginTop: "24px" }}
          variant="contained"
        >
          Tworzenie konta pracownika
        </Button>
      </div>
      <Collapse in={isFormVisible}>
        <CaMainContainer elevation={12}>
          <CaItem>
            <Typography variant="caption">Email</Typography>
            <TextField name="email" required />
          </CaItem>
          <CaItem>
            <Typography variant="caption">Imię</Typography>
            <TextField name="firstName" required />
          </CaItem>
          <CaItem>
            <Typography variant="caption">Nazwisko</Typography>
            <TextField name="lastName" required />
          </CaItem>
          <CaItem>
            <Typography variant="caption">Hasło</Typography>
            <TextField name="password" required />
          </CaItem>
          <CaItem>
            <Typography variant="caption">Pesel</Typography>
            <TextField name="pesel" required fullWidth />
          </CaItem>
          <CaItem>
            <Typography variant="caption">
              Ilość przepracowanych lat w momencie zatrudnienia
            </Typography>
            <TextField name="years" required />
          </CaItem>
          <CaItem>
            <Typography variant="caption">Data zatrudnienia</Typography>

            <LocalizationProvider
              dateAdapter={AdapterDateFns}
              adapterLocale={plLocale}
            >
              <DesktopDatePicker
                value={hiringDate}
                onChange={handleChangeHiringDate}
                renderInput={(params) => <TextField {...params} />}
                maxDate={maxHiringDate}
              />
            </LocalizationProvider>
          </CaItem>
          <Button type="submit" variant="contained">
            Stwórz konto
          </Button>
        </CaMainContainer>
      </Collapse>
    </Stack>
  );
};

export default CreateAccount;
