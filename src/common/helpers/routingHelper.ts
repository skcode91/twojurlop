import { Pages } from "../enums/Pages";

export const getPageUrl = (page: Pages): string => {
  switch (page) {
    case Pages.signIn:
      return "/sign-in/";
    default:
      return "/";
  }
};
