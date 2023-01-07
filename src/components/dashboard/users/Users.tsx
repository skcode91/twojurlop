import { Typography } from "@mui/material";
import React from "react";
import DashboardLayout from "src/common/components/dashboard-layout/DashboardLayout";
import CreateAccount from "./create-account/CreateAccount";

const Users = () => {
  return (
    <DashboardLayout>
      <Typography variant="h2">Pracownicy</Typography>
      <CreateAccount />
    </DashboardLayout>
  );
};

export default Users;
