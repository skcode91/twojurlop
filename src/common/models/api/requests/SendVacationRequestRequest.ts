export interface SendVacationRequest {
  userId: number;
  startDate: Date;
  endDate: Date;
  daysCount: number;
}
