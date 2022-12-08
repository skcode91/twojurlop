import { createApiClient } from "src/common/configs/axiosClientConfig";

export const apiClient = createApiClient(
  "https://twojurlop.azurewebsites.net/api/"
);
