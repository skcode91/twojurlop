import { Stack } from "@mui/system";
import router from "next/router";
import React, { useCallback, useState } from "react";
import { Pages } from "src/common/enums/Pages";
import { Roles } from "src/common/enums/Roles";
import { getPageUrl } from "src/common/helpers/routingHelper";
import DashboardLayoutProps from "./DashboardLayoutProps";
import { LcBodyContainer, LMainContainer } from "./DashboardLayoutStyles";
import SideBar from "./side-bar/SideBar";
import SideBarItem from "./side-bar/SideBarItem";
import TopBar from "./top-bar/TopBar";

const menuItems: SideBarItem[] = [
  {
    id: 0,
    name: "Pracownicy",
    page: Pages.users,
    access: Roles.Manager,
  },
  {
    id: 1,
    name: "Urlopy",
    page: Pages.vacations,
    access: Roles.Manager,
  },
  {
    id: 2,
    name: "Prośby o urlop",
    page: Pages.vacationRequests,
    access: Roles.Manager,
  },
];

const DashboardLayout = (props: DashboardLayoutProps) => {
  const [activeItemId, setActiveItemId] = useState<number>(0);

  const redirectToPage = async (page: Pages) => {
    await router.push(getPageUrl(page));
  };

  return (
    <LMainContainer>
      <TopBar />
      <Stack display="flex" direction="row">
        <SideBar items={menuItems} activeItemId={activeItemId} />
        <LcBodyContainer>{props.children}</LcBodyContainer>
      </Stack>
    </LMainContainer>
  );
};

export default DashboardLayout;
