import { Snackbar, Typography } from "@mui/material";
import router from "next/router";
import React, { useCallback, useContext, useEffect, useState } from "react";
import {
  changeUserRoleRequest,
  changeUserStatusRequest,
  getUsersRequest,
} from "src/api/userApi";
import DashboardLayout from "src/common/components/dashboard-layout/DashboardLayout";
import { UserContext } from "src/common/contexts/UserContext";
import { Pages } from "src/common/enums/Pages";
import { Roles } from "src/common/enums/Roles";
import { Status } from "src/common/enums/Status";
import { getPageUrl } from "src/common/helpers/routingHelper";
import { ChangeUserStatusRequest } from "src/common/models/api/requests/ChageUserStatusRequest";
import { ChangeUserRoleRequest } from "src/common/models/api/requests/ChangeUserRoleRequest";
import { UserDto } from "src/common/models/dto/UserDto";
import CreateAccount from "./components/create-account/CreateAccount";
import UsersList from "./components/users-list/UsersList";

const Users = () => {
  const [users, setUsers] = useState<UserDto[]>([]);
  const [snackbarMessage, setSnackbarMessage] = useState<string>("");

  const userContext = useContext(UserContext);
  const userId = userContext.user?.userId;

  const getUsers = useCallback(async () => {
    if (!userId) {
      await router.push(getPageUrl(Pages.signIn));
      return;
    }
    try {
      const response = await getUsersRequest({ currentUserId: userId });
      setUsers(response);
    } catch {
      setSnackbarMessage("Coś poszło nie tak");
    }
  }, [userId]);

  useEffect(() => {
    getUsers();
  }, [getUsers]);

  const handleDeleteUser = useCallback(
    async (user: UserDto) => {
      if (!userId) {
        await router.push(getPageUrl(Pages.signIn));
        return;
      }
      try {
        const request: ChangeUserStatusRequest = {
          currentUserId: userId,
          userId: user.id,
          statusId: Status.Deleted,
        };
        await changeUserStatusRequest(request);
        getUsers();
        setSnackbarMessage("Usunięto uzytkownika");
      } catch {
        setSnackbarMessage("Coś poszło nie tak");
      }
    },
    [getUsers, userId]
  );

  const handleChangeRole = useCallback(
    async (user: UserDto, role: Roles) => {
      if (!userId) {
        await router.push(getPageUrl(Pages.signIn));
        return;
      }
      try {
        const request: ChangeUserRoleRequest = {
          currentUserId: userId,
          userId: user.id,
          roleId: role,
        };
        await changeUserRoleRequest(request);
        getUsers();
        setSnackbarMessage("Pomyślnie zmieniono rolę");
      } catch {
        setSnackbarMessage("Coś poszło nie tak");
      }
    },
    [getUsers, userId]
  );

  return (
    <DashboardLayout>
      <Snackbar
        open={Boolean(snackbarMessage)}
        onClose={() => setSnackbarMessage("")}
        autoHideDuration={6000}
        message={snackbarMessage}
      />
      <Typography variant="h2">Pracownicy</Typography>
      <CreateAccount />
      <UsersList
        handleDeleteUser={handleDeleteUser}
        handleChangeRole={handleChangeRole}
        users={users}
      />
    </DashboardLayout>
  );
};

export default Users;
