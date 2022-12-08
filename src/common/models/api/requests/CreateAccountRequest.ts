import { Gender } from "src/common/enums/Gender";

export interface CreateAccountRequest {
  password: string;
  email: string;
  userName: string;
  firstName: string;
  lastName: string;
  gender: Gender;
  pesel: number;
}
