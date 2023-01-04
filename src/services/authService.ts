import { signInRequest } from "src/api/authorizationApi";
import { ClaimTypes } from "src/common/enums/ClaimTypes";
import { Roles } from "src/common/enums/Roles";
import { decodeJWT } from "src/common/helpers/jwtHelper";
import { SignInRequest } from "src/common/models/api/requests/SignInRequest";
import { SignInResponse } from "src/common/models/api/responses/SignInResponse";
import { UserContextUser } from "src/common/models/common/UserContext";

export const signIn = async (
  request: SignInRequest,
  setUserContext: React.Dispatch<
    React.SetStateAction<UserContextUser | undefined>
  >
): Promise<SignInResponse> => {
  const response = await signInRequest(request);
  setTokensInUserContext(response, setUserContext);
  return response;
};

export const setTokensInUserContext = (
  response: SignInResponse,
  setUserContext: React.Dispatch<
    React.SetStateAction<UserContextUser | undefined>
  >
): void => {
  const jwt = decodeJWT(response.accessToken);
  const roles = jwt[ClaimTypes.Role];

  const userContextValue: UserContextUser = {
    isLogged: true,
    userId: parseInt(jwt[ClaimTypes.Subject]),
    accessTokenExpirationDate: new Date(response.accessTokenValidTo),
    role: getClaimArray(roles)[0],
    allegroAccessTokenExpirationDate: undefined,
  };

  localStorage.setItem("UserContext", JSON.stringify(userContextValue));
  localStorage.setItem(
    "AccessToken",
    response.accessToken ? response.accessToken : ""
  );
  userContextValue.isTokenBeingChecked = false;
  setUserContext((userContext) => ({ ...userContext, ...userContextValue }));
};

const getClaimArray = (claimArray: string | string[]) => {
  return claimArray
    ? Array.isArray(claimArray)
      ? claimArray.map((x) => parseInt(x))
      : [parseInt(claimArray)]
    : [];
};

export const signOut = async (
  setUserContext: React.Dispatch<
    React.SetStateAction<UserContextUser | undefined>
  >
) => {
  localStorage.setItem("UserContext", "");
  localStorage.setItem("AccessToken", "");
  setUserContext(() => undefined);
};
