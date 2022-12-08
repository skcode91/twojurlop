import { ClaimTypes } from "src/common/enums/ClaimTypes";

export interface JWT {
  [ClaimTypes.Role]: string | string[];
  [ClaimTypes.NameIdentifier]: string;
  [ClaimTypes.Subject]: string;
  exp: number;
  jti: string;
  iat: string;
  iss: string;
  aud: string;
}
