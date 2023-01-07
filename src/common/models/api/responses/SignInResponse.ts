export interface SignInResponse {
  accessToken: string;
  accessTokenValidTo: string;

  userId: number;
  roleId: number;
}
