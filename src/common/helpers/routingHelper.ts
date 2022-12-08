import { Pages } from "../enums/Pages";

export const getPageUrl = (page: Pages): string => {
  switch (page) {
    case Pages.signIn:
      return "/sign-in/";
    case Pages.signOut:
      return "/sign-out/";
    case Pages.dashboard:
      return "/dashboard/";
    default:
      return "/";
  }
};
