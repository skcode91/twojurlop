import { Roles } from "../../enums/Roles";
import { User } from "../api/User";

export interface UserContextUser {
  isTokenBeingChecked?: boolean;
  accessTokenExpirationDate: Date;
  allegroAccessTokenExpirationDate: Date | undefined;
  isLogged: boolean;

  userId: number;
  role: Roles;

  userDetails?: User;
}

export interface UserContext {
  user?: UserContextUser;
  setUserContextUser: React.Dispatch<
    React.SetStateAction<UserContextUser | undefined>
  >;
}
