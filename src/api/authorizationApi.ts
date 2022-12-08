import { CreateAccountRequest } from "src/common/models/api/requests/CreateAccountRequest";
import { SignInRequest } from "src/common/models/api/requests/SignInRequest";
import { SignInResponse } from "src/common/models/api/responses/SignInResponse";
import { apiClient } from "./apiClient";

const controllerName = "Authorization";

export const createAccountRequest = async (
  request: CreateAccountRequest
): Promise<void> => {
  await apiClient.post(controllerName + "/create-account", request);
};

export const signInRequest = async (
  request: SignInRequest
): Promise<SignInResponse> => {
  const response = await apiClient.post(controllerName + "/sign-in", request);
  return response.data;
};
