import type { AppProps } from "next/app";
import "@styles/index.css";
import { useMemo, useState } from "react";
import { UserContextUser } from "src/common/models/common/UserContext";
import {
  getPersistedUserContextUser,
  UserContext,
} from "src/common/contexts/UserContext";

export default function App({ Component, pageProps }: AppProps) {
  const [userContextUser, setUserContextUser] = useState<
    UserContextUser | undefined
  >(getPersistedUserContextUser());

  const userContextValue = useMemo(
    () =>
      userContextUser
        ? { user: userContextUser, setUserContextUser }
        : { setUserContextUser },
    [userContextUser]
  );

  return (
    <div>
      <UserContext.Provider value={userContextValue}>
        <Component {...pageProps} />
      </UserContext.Provider>
    </div>
  );
}
