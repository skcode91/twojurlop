import { AddUserRequest } from "src/common/models/api/requests/AddUserRequest";
import { ChangeUserStatusRequest } from "src/common/models/api/requests/ChageUserStatusRequest";
import { ChangeUserRoleRequest } from "src/common/models/api/requests/ChangeUserRoleRequest";
import { GetUserBaseInfoRequest } from "src/common/models/api/requests/GetUserBaseInfoRequest";
import { GetUsersRequest } from "src/common/models/api/requests/GetUsersRequest";
import { UserDto } from "src/common/models/dto/UserDto";
import { apiClient } from "./apiClient";

const controllerName = "User";

export const getUserBaseInfoRequest = async (
  request: GetUserBaseInfoRequest
): Promise<UserDto> => {
  const response = await apiClient.get(controllerName + "/user-base-info", {
    params: { ...request },
  });
  return response.data;
};

export const addUserRequest = async (
  request: AddUserRequest
): Promise<void> => {
  await apiClient.post(controllerName + "/user-add", request);
};

export const changeUserRoleRequest = async (
  request: ChangeUserRoleRequest
): Promise<void> => {
  await apiClient.post(controllerName + "/change-user-role", request);
};

export const changeUserStatusRequest = async (
  request: ChangeUserStatusRequest
): Promise<void> => {
  await apiClient.post(controllerName + "/change-user-status", request);
};

export const getUsersRequest = async (
  request: GetUsersRequest
): Promise<UserDto[]> => {
  const response = await apiClient.get(controllerName + "/users", {
    params: { ...request },
  });
  return response.data;
};
