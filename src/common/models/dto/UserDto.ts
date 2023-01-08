import { Gender } from "src/common/enums/Gender";
import { Roles } from "src/common/enums/Roles";

export interface UserDto {
  id: number;
  email: string;
  firstName: string;
  lastName: string;
  roleId: Roles;
  pesel: number;
  hiringDate: Date;
  numberOfYearsWorkedOnHiringDate: number;
  genderId: Gender;
}
