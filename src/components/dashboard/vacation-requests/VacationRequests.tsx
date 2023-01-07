import { Snackbar, Stack, Typography } from "@mui/material";
import router from "next/router";
import React, { useCallback, useContext, useEffect, useState } from "react";
import {
  deleteVacationRequestRequest,
  getVacationRequestsRequest,
  handleVacationRequestRequest,
  sendVacationRequestRequest,
} from "src/api/vacationApi";
import DashboardLayout from "src/common/components/dashboard-layout/DashboardLayout";
import { UserContext } from "src/common/contexts/UserContext";
import { Pages } from "src/common/enums/Pages";
import { VacationRequestStatus } from "src/common/enums/VacationRequestStatus";
import { getPageUrl } from "src/common/helpers/routingHelper";
import { DeleteVacationRequestRequest } from "src/common/models/api/requests/DeleteVacationRequestRequest";
import { GetVacationRequestsRequest } from "src/common/models/api/requests/GetVacationRequestsRequest";
import { HandleVacationRequestRequest } from "src/common/models/api/requests/HandleVacationRequestRequest";
import { SendVacationRequest } from "src/common/models/api/requests/SendVacationRequestRequest";
import { VacationRequestDto } from "src/common/models/dto/VacationRequestDto";
import CreateVacationRequest from "./components/create-vacation-request/CreateVacationRequest";
import VacationRequestsList from "./components/vacation-requests-list/VacationRequestsList";

const VacationRequests = () => {
  const [snackbarMessage, setSnackbarMessage] = useState<string>("");
  const userContext = useContext(UserContext);
  const userId = userContext.user?.userId;
  const [year, setYear] = useState<number>(new Date().getFullYear());

  const [vacationRequests, setVacationRequests] = useState<
    VacationRequestDto[] | undefined
  >();

  const getVacationRequests = useCallback(
    async (newYear?: number) => {
      setVacationRequests(undefined);
      if (!userId) {
        await router.push(getPageUrl(Pages.signIn));
        return;
      }
      try {
        const request: GetVacationRequestsRequest = {
          year: newYear ? newYear : year,
          userId: userId,
        };

        const response = await getVacationRequestsRequest(request);
        setVacationRequests(response.vacationRequests);
      } catch {
        setSnackbarMessage("Błąd pobierania próśb o urlop");
      }
    },
    [userId, year]
  );

  const handleSendVacationRequest = useCallback(
    async (request: SendVacationRequest) => {
      try {
        await sendVacationRequestRequest(request);
        setSnackbarMessage("Wysłano prośbę o urlop");
        getVacationRequests();
      } catch {
        setSnackbarMessage("Coś poszło nie tak");
      }
      getVacationRequests();
    },
    [getVacationRequests]
  );

  const handleDeleteRequest = useCallback(
    async (req: VacationRequestDto) => {
      try {
        const request: DeleteVacationRequestRequest = {
          userId: req.userId,
          vacationRequestId: req.id,
        };
        await deleteVacationRequestRequest(request);
        getVacationRequests();
        setSnackbarMessage("Pomyślnie usunięto zapytanie");
      } catch {
        setSnackbarMessage("Nie udało się usunąć zapytania");
      }
    },
    [getVacationRequests]
  );

  useEffect(() => {
    getVacationRequests();
  }, [getVacationRequests]);

  const changeYear = (year: number) => {
    setYear(year);
    getVacationRequests(year);
  };

  const handleVacationRequest = useCallback(
    async (request: HandleVacationRequestRequest) => {
      try {
        await handleVacationRequestRequest(request);
        setSnackbarMessage(
          request.newRequestStatus === VacationRequestStatus.Accepted
            ? "Pomyślnie zaakceptowano prośbę o urlop"
            : "Odrzucono prośbę o urlop"
        );
        getVacationRequests();
      } catch {
        setSnackbarMessage("Coś poszło nie tak");
      }
    },
    [getVacationRequests]
  );

  return (
    <DashboardLayout>
      <Snackbar
        open={Boolean(snackbarMessage)}
        onClose={() => setSnackbarMessage("")}
        autoHideDuration={6000}
        message={snackbarMessage}
      />
      <Stack display="flex" direction="column" gap="24px">
        <Typography variant="h2">Prośby o urlop</Typography>
        <CreateVacationRequest
          handleSendVacationRequest={handleSendVacationRequest}
        />
        <VacationRequestsList
          vacationRequests={vacationRequests}
          handleDelete={handleDeleteRequest}
          year={year}
          setYear={changeYear}
          handleVacationRequest={handleVacationRequest}
        />
      </Stack>
    </DashboardLayout>
  );
};

export default VacationRequests;
