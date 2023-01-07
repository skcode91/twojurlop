import { SendVacationRequest } from "src/common/models/api/requests/SendVacationRequestRequest";

export interface CreateVacationRequestProps {
  handleSendVacationRequest: (request: SendVacationRequest) => Promise<void>;
}
