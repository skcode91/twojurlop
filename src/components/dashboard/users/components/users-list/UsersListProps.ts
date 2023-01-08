import { Roles } from "src/common/enums/Roles";
import { UserDto } from "src/common/models/dto/UserDto";

export interface UsersListProps {
  users: UserDto[];
  handleDeleteUser: (user: UserDto) => void;
  handleChangeRole: (user: UserDto, role: Roles) => void;
}
