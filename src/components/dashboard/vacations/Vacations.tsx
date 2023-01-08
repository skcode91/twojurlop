import { Snackbar, Typography } from "@mui/material";
import router from "next/router";
import React, { useCallback, useContext, useEffect, useState } from "react";
import { getVacationsRequest } from "src/api/vacationApi";
import DashboardLayout from "src/common/components/dashboard-layout/DashboardLayout";
import { UserContext } from "src/common/contexts/UserContext";
import { Pages } from "src/common/enums/Pages";
import { getPageUrl } from "src/common/helpers/routingHelper";
import { GetVacationsRequest } from "src/common/models/api/requests/GetVacationsRequest";
import { VacationDto } from "src/common/models/dto/VacationDto";
import VacationsList from "./components/vacations-list/VacationsList";

const Vacations = () => {
  const [vacations, setVacations] = useState<VacationDto[]>([]);
  const [snackbarMessage, setSnackbarMessage] = useState<string>("");

  const userContext = useContext(UserContext);
  const userId = userContext.user?.userId;
  const [year, setYear] = useState<number>(new Date().getFullYear());

  const getVacations = useCallback(
    async (newYear?: number) => {
      if (!userId) {
        await router.push(getPageUrl(Pages.signIn));
        return;
      }
      try {
        const request: GetVacationsRequest = {
          year: newYear ? newYear : year,
          userId: userId,
        };
        const response = await getVacationsRequest(request);
        setVacations(response.vacations);
      } catch {
        setSnackbarMessage("Coś poszło nie tak");
      }
    },
    [userId, year]
  );

  useEffect(() => {
    getVacations();
  }, [getVacations]);

  const changeYear = (year: number) => {
    setYear(year);
    getVacations(year);
  };

  return (
    <DashboardLayout>
      <Snackbar
        open={Boolean(snackbarMessage)}
        onClose={() => setSnackbarMessage("")}
        autoHideDuration={6000}
        message={snackbarMessage}
      />
      <Typography variant="h2">Urlopy</Typography>
      <VacationsList vacations={vacations} year={year} setYear={changeYear} />
    </DashboardLayout>
  );
};

export default Vacations;
