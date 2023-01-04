import { Router } from "next/router";
import { Pages } from "../enums/Pages";
import { getWindow } from "./windowHelper";

export const getPageUrl = (page: Pages): string => {
  switch (page) {
    case Pages.signIn:
      return "/sign-in/";
    case Pages.signOut:
      return "/sign-out/";
    case Pages.dashboard:
      return "/dashboard/";
    case Pages.vacations:
      return "/dashboard/vacations/";
    case Pages.vacationRequests:
      return "/dashboard/vacation-requests/";
    case Pages.users:
      return "/dashboard/users/";
    default:
      return "/";
  }
};

export const isCurrentRoute = (route: Pages): boolean => {
  const window = getWindow();
  if (!window) return false;

  return getPageUrl(route).includes(window.location.pathname) &&
    window.location.pathname !== "/dashboard"
    ? true
    : false;
};
