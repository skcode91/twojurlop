import {
  Button,
  Collapse,
  Paper,
  Snackbar,
  TextField,
  Typography,
} from "@mui/material";
import { Stack } from "@mui/system";
import React, { useCallback, useContext, useMemo, useState } from "react";
import { CaItem, CaMainContainer } from "./CreateAccountStyles";
import { AdapterDateFns } from "@mui/x-date-pickers/AdapterDateFns";
import { LocalizationProvider } from "@mui/x-date-pickers";
import { DesktopDatePicker } from "@mui/x-date-pickers";
import plLocale from "date-fns/locale/pl";
import { AddUserRequest } from "src/common/models/api/requests/AddUserRequest";
import { UserContext } from "src/common/contexts/UserContext";
import router from "next/router";
import { getPageUrl } from "src/common/helpers/routingHelper";
import { Pages } from "src/common/enums/Pages";
import { addUserRequest } from "src/api/userApi";
import { CreateAccountProps } from "./CreateAccountProps";

const initData: AddUserRequest = {
  email: "",
  firstName: "",
  lastName: "",
  password: "",
  numberOfYearsWorkedOnHiringDate: 0,
  hiringDate: new Date(),
  genderId: 2,
  currentUserId: 0,
  pesel: "",
};

const CreateAccount = (props: CreateAccountProps) => {
  const [isFormVisible, setIsFormVisible] = useState(false);

  const [hiringDate, setHiringDate] = useState<Date>(new Date());
  const maxHiringDate = new Date();

  const [userData, setUserData] = useState<AddUserRequest>(initData);
  const [snackbarMessage, setSnackbarMessage] = useState<string>("");

  const userContext = useContext(UserContext);
  const userId = userContext.user?.userId;

  const handleChangeHiringDate = (date: Date | null) => {
    if (date) setHiringDate(date);
  };

  const isFormValid = useMemo(
    () =>
      userData &&
      Boolean(userData.email) &&
      Boolean(userData.firstName) &&
      Boolean(userData.lastName) &&
      Boolean(userData.numberOfYearsWorkedOnHiringDate) &&
      Boolean(userData.password) &&
      Boolean(userData.pesel),
    [userData]
  );

  const addUser = useCallback(
    async (e: React.FormEvent<HTMLFormElement>) => {
      e.preventDefault();
      if (!userId) {
        await router.push(getPageUrl(Pages.signIn));
        return;
      }
      try {
        const request: AddUserRequest = {
          ...userData,
          currentUserId: userId,
          hiringDate: hiringDate,
        };

        await addUserRequest(request);
        setSnackbarMessage("Pomyślnie stworzono konto");
        setUserData(initData);
        setIsFormVisible(false);
        props.getUsers();
      } catch {
        setSnackbarMessage("Coś poszło nie tak");
      }
    },
    [hiringDate, props, userData, userId]
  );

  return (
    <Stack display="flex" component="form" onSubmit={(e) => addUser(e)}>
      <Snackbar
        open={Boolean(snackbarMessage)}
        onClose={() => setSnackbarMessage("")}
        autoHideDuration={6000}
        message={snackbarMessage}
      />
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
            <TextField
              value={userData.email}
              name="email"
              required
              onChange={(e) =>
                setUserData({ ...userData, email: e.target.value })
              }
            />
          </CaItem>
          <CaItem>
            <Typography variant="caption">Imię</Typography>
            <TextField
              value={userData.firstName}
              onChange={(e) =>
                setUserData({ ...userData, firstName: e.target.value })
              }
              name="firstName"
              required
            />
          </CaItem>
          <CaItem>
            <Typography variant="caption">Nazwisko</Typography>
            <TextField
              value={userData.lastName}
              onChange={(e) =>
                setUserData({ ...userData, lastName: e.target.value })
              }
              name="lastName"
              required
            />
          </CaItem>
          <CaItem>
            <Typography variant="caption">Hasło</Typography>
            <TextField
              value={userData.password}
              onChange={(e) =>
                setUserData({ ...userData, password: e.target.value })
              }
              name="password"
              required
            />
          </CaItem>
          <CaItem>
            <Typography variant="caption">Pesel</Typography>
            <TextField
              value={userData.pesel}
              onChange={(e) =>
                setUserData({ ...userData, pesel: e.target.value })
              }
              name="pesel"
              required
              fullWidth
            />
          </CaItem>
          <CaItem>
            <Typography variant="caption">
              Ilość przepracowanych lat w momencie zatrudnienia
            </Typography>
            <TextField
              value={userData.numberOfYearsWorkedOnHiringDate}
              type="text"
              onChange={(e) =>
                setUserData({
                  ...userData,
                  numberOfYearsWorkedOnHiringDate: Number(e.target.value),
                })
              }
              name="years"
              required
            />
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
          <Button type="submit" variant="contained" disabled={!isFormValid}>
            Stwórz konto
          </Button>
        </CaMainContainer>
      </Collapse>
    </Stack>
  );
};

export default CreateAccount;
