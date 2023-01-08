import { Status } from "src/common/enums/Status";

export interface ChangeUserStatusRequest {
  userId: number;
  currentUserId: number;
  statusId: Status;
}
