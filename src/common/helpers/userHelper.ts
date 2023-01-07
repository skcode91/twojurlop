import { Roles } from "../enums/Roles";

export const getRoleById = (roleId: number): Roles => {
  switch (roleId) {
    case 1:
      return Roles.Admin;
    case 2:
      return Roles.Manager;
    case 3:
      return Roles.User;
    default:
      return Roles.User;
  }
};
