import { Gender } from "src/common/enums/Gender";

export interface AddUserRequest {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  genderId: Gender;
  pesel: string;
  numberOfYearsWorkedOnHiringDate: number;
  hiringDate: Date;
  currentUserId: number;
}
