import axios, { AxiosRequestConfig, AxiosInstance } from "axios";

export const createApiClient = (baseUrl: string): AxiosInstance => {
  const apiClient = axios.create({
    baseURL: baseUrl,
    headers: {
      "X-XSRF-TOKEN": "",
    },
  });

  apiClient.interceptors.request.use((config: AxiosRequestConfig) => {
    const accessToken = localStorage.getItem("AccessToken");

    if (accessToken) {
      config.headers = {
        ...config.headers,
        Authorization: `Bearer ${accessToken}`,
      };
    }

    return config;
  });

  return apiClient;
};
