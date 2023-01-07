import { VacationRequestStatus } from "src/common/enums/VacationRequestStatus";

export interface VacationRequestDto {
  id: number;
  userId: number;
  userFullName: string;
  startDate: Date;
  endDate: Date;
  daysCount: number;
  statusId: VacationRequestStatus;
}
