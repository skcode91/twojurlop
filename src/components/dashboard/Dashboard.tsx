import { Typography } from "@mui/material";
import { useRouter } from "next/router";
import { useContext } from "react";
import DashboardLayout from "src/common/components/dashboard-layout/DashboardLayout";
import { UserContext } from "src/common/contexts/UserContext";
import { Pages } from "src/common/enums/Pages";
import { getPageUrl } from "src/common/helpers/routingHelper";

const Dashboard = () => {
  const userContext = useContext(UserContext);
  const isLogged = userContext?.user?.isLogged;
  const router = useRouter();

  const redirectToPage = async (page: Pages) => {
    await router.push(getPageUrl(page));
  };

  return (
    <DashboardLayout>
      <div>
        <Typography variant="h4">Witamy w aplikacji Twój urlop!</Typography>
      </div>
    </DashboardLayout>
  );
};

export default Dashboard;
