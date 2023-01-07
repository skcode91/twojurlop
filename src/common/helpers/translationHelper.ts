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
