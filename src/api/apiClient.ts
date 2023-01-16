import { createApiClient } from "src/common/configs/axiosClientConfig";

export const apiClient = createApiClient(
  "https://api-twoj-urlop.azurewebsites.net/api/"
);
