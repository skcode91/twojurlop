import { Roles } from "src/common/enums/Roles";

export interface ChangeUserRoleRequest {
  userId: number;
  currentUserId: number;
  roleId: Roles;
}
