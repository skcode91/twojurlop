import { Pages } from "src/common/enums/Pages";
import { Roles } from "src/common/enums/Roles";

export default interface SideBarItem {
  id: number;
  name: string;
  access: Roles;
  page: Pages;
}
