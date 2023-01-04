import React, { useContext } from "react";
import { TbMainContainer } from "./TopBarStyles";
import LogoutIcon from "@mui/icons-material/Logout";
import HomeIcon from "@mui/icons-material/Home";
import { IconButton, Typography } from "@mui/material";
import { signOut } from "src/services/authService";
import { UserContext } from "src/common/contexts/UserContext";
import router from "next/router";
import { getPageUrl } from "src/common/helpers/routingHelper";
import { Pages } from "src/common/enums/Pages";
import { Stack } from "@mui/system";

const TopBar = () => {
  const { setUserContextUser } = useContext(UserContext);

  const redirectToDashboard = async () => {
    await router.push(getPageUrl(Pages.dashboard));
  };

  const handleSignOut = async () => {
    await signOut(setUserContextUser);
    await router.push(getPageUrl(Pages.signIn));
  };

  return (
    <TbMainContainer elevation={16}>
      <Typography variant="h6">Twój Urlop</Typography>
      <Stack display="flex" flexDirection="row">
        <IconButton onClick={() => redirectToDashboard()}>
          <HomeIcon />
        </IconButton>
        <IconButton onClick={() => handleSignOut()}>
          <LogoutIcon />
        </IconButton>
      </Stack>
    </TbMainContainer>
  );
};

export default TopBar;
