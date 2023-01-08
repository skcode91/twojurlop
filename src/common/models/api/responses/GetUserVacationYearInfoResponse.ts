import { UserDto } from "../../dto/UserDto";
import { VacationDto } from "../../dto/VacationDto";
import { VacationRequestDto } from "../../dto/VacationRequestDto";

export interface GetUserVacationYearInfoResponse {
  user: UserDto;
  vacations: VacationDto[];
  requests: VacationRequestDto[];
  daysTotal: number;
  daysLeft: number;
  year: number;
}
