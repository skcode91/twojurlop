import { DeleteVacationRequestRequest } from "src/common/models/api/requests/DeleteVacationRequestRequest";
import { GetVacationRequestsRequest } from "src/common/models/api/requests/GetVacationRequestsRequest";
import { GetVacationsRequest } from "src/common/models/api/requests/GetVacationsRequest";
import { HandleVacationRequestRequest } from "src/common/models/api/requests/HandleVacationRequestRequest";
import { SendVacationRequest } from "src/common/models/api/requests/SendVacationRequestRequest";
import { GetVacationRequestsResponse } from "src/common/models/api/responses/GetVacationRequestsResponse";
import { GetVacationsResponse } from "src/common/models/api/responses/GetVacationsResponse";
import { apiClient } from "./apiClient";

const controllerName = "vacation";

export const sendVacationRequestRequest = async (
  request: SendVacationRequest
): Promise<void> => {
  await apiClient.post(controllerName + "/vacation-request-send", request);
};

export const getVacationRequestsRequest = async (
  request: GetVacationRequestsRequest
): Promise<GetVacationRequestsResponse> => {
  const response = await apiClient.get(controllerName + "/vacation-request", {
    params: { ...request },
  });
  return response.data;
};

export const deleteVacationRequestRequest = async (
  request: DeleteVacationRequestRequest
): Promise<void> => {
  await apiClient.delete(controllerName + "/vacation-request", {
    data: request,
  });
};

export const handleVacationRequestRequest = async (
  request: HandleVacationRequestRequest
): Promise<void> => {
  await apiClient.post(controllerName + "/vacation-request-handle", request);
};

export const getVacationsRequest = async (
  request: GetVacationsRequest
): Promise<GetVacationsResponse> => {
  const response = await apiClient.get(controllerName + "/vacation", {
    params: { ...request },
  });
  return response.data;
};
