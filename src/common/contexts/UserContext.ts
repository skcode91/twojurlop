import { createContext } from "react";
import {
  UserContextUser,
  UserContext as UserContextModel,
} from "src/common/models/common/UserContext";
import { getWindow } from "src/common/helpers/windowHelper";
import { getLocalStorageObject } from "../helpers/localStorageHelper";

export const getPersistedUserContextUser = (): UserContextUser | undefined => {
  if (getWindow()) {
    const user = getLocalStorageObject<UserContextUser>("UserContext");
    if (user) {
      user.accessTokenExpirationDate = new Date(user.accessTokenExpirationDate);
      user.isTokenBeingChecked = true;
      return user;
    }
    return undefined;
  }

  return undefined;
};

export const UserContext = createContext<UserContextModel>(null as any);
