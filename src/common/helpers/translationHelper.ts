import { Roles } from "../enums/Roles";
import { Status } from "../enums/Status";
import { VacationRequestStatus } from "../enums/VacationRequestStatus";

export const getVacationRequestStatusName = (status: VacationRequestStatus) => {
  switch (status) {
    case VacationRequestStatus.Active:
      return "Aktywna";
    case VacationRequestStatus.Accepted:
      return "Zaakceptowana";
    case VacationRequestStatus.Declined:
      return "Odrzucona";
    case VacationRequestStatus.Deleted:
      return "Usunięta";
  }
};

export const getRoleTranslation = (role: Roles): string => {
  switch (role) {
    case Roles.Admin:
      return "Admin";
    case Roles.Manager:
      return "Manager";
    case Roles.User:
      return "Pracownik";
    default:
      return "";
  }
};

export const getStatusName = (status: Status): string => {
  switch (status) {
    case Status.Active:
      return "Aktywny";
    case Status.Deleted:
      return "Konto usunięte";
  }
};
