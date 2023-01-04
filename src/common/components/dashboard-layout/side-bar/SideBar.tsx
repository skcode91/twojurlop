import { Divider, MenuItem, Typography } from "@mui/material";
import router from "next/router";
import React from "react";
import { Pages } from "src/common/enums/Pages";
import { getPageUrl, isCurrentRoute } from "src/common/helpers/routingHelper";
import SideBarProps from "./SideBarProps";
import { SbMainContainer, SbMenuContainer, SbMenuItem } from "./SideBarStyles";

const SideBar = (props: SideBarProps) => {
  const { items, activeItemId } = props;

  const redirectToPage = async (page: Pages) => {
    await router.push(getPageUrl(page));
  };

  return (
    <SbMainContainer elevation={16}>
      <Typography variant="h6">Menu</Typography>
      <Divider />
      <SbMenuContainer>
        {items.map((item) => (
          <SbMenuItem
            selected={isCurrentRoute(item.page)}
            key={item.id}
            onClick={() => redirectToPage(item.page)}
          >
            {item.name}
          </SbMenuItem>
        ))}
      </SbMenuContainer>
    </SbMainContainer>
  );
};

export default SideBar;
