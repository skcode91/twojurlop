export interface SignInResponse {
  accessToken: string;
  accessTokenValidTo: string;

  refreshToken: string;
  refreshTokenValidTo: string;
}
