import { Stack } from "@mui/system";
import router from "next/router";
import React, { useCallback, useContext, useMemo, useState } from "react";
import { UserContext } from "src/common/contexts/UserContext";
import { Pages } from "src/common/enums/Pages";
import { Roles } from "src/common/enums/Roles";
import { getPageUrl } from "src/common/helpers/routingHelper";
import { isManagerOrAdmin } from "src/common/helpers/userHelper";
import DashboardLayoutProps from "./DashboardLayoutProps";
import {
  LBodyVertical,
  LcBodyContainer,
  LMainContainer,
} from "./DashboardLayoutStyles";
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
    access: Roles.User,
  },
  {
    id: 2,
    name: "Prośby o urlop",
    page: Pages.vacationRequests,
    access: Roles.User,
  },
];

const DashboardLayout = (props: DashboardLayoutProps) => {
  const [activeItemId, setActiveItemId] = useState<number>(0);
  const userContext = useContext(UserContext);
  const userRole = useMemo(
    () => userContext.user?.role,
    [userContext.user?.role]
  );
  const isLogged = userContext?.user?.isLogged;

  const redirectToPage = async (page: Pages) => {
    await router.push(getPageUrl(page));
  };

  const filteredMenuItems = useMemo(
    () =>
      menuItems.filter((item) =>
        !isManagerOrAdmin(userRole ?? Roles.User)
          ? item.access === Roles.User
          : true
      ),
    [userRole]
  );

  return (
    <LMainContainer>
      <TopBar />
      <LBodyVertical>
        <SideBar items={filteredMenuItems} activeItemId={activeItemId} />
        <LcBodyContainer>
          {isLogged ? props.children : "Nie jesteś zalogowany"}
        </LcBodyContainer>
      </LBodyVertical>
    </LMainContainer>
  );
};

export default DashboardLayout;
