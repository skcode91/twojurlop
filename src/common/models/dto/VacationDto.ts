import { UserDto } from "./UserDto";

export interface VacationDto {
  id: number;
  startDate: Date;
  endDate: Date;
  daysCount: number;
  userId: number;
  user?: UserDto;
}
