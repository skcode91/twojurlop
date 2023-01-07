import { Alert, Collapse, TextField } from "@mui/material";
import { useRouter } from "next/router";
import React, { useContext, useState } from "react";
import { useForm } from "react-hook-form";
import { UserContext } from "src/common/contexts/UserContext";
import { Pages } from "src/common/enums/Pages";
import { customRefNameRegister } from "src/common/helpers/reactHookFormHelper";
import { getPageUrl } from "src/common/helpers/routingHelper";
import { SignInRequest } from "src/common/models/api/requests/SignInRequest";
import { signIn } from "src/services/authService";

const SignIn = () => {
  const { setUserContextUser } = useContext(UserContext);
  const router = useRouter();
  const [isErrorVisible, setIsErrorVisible] = useState(false);

  const { register, handleSubmit } = useForm<SignInRequest>({
    mode: "onChange",
  });

  const onSubmit = async (data: SignInRequest) => {
    try {
      setIsErrorVisible(false);
      await signIn(data, setUserContextUser);
      await router.push(getPageUrl(Pages.dashboard));
    } catch (ex) {
      setIsErrorVisible(true);
    }
  };

  return (
    <form className="box-form" onSubmit={handleSubmit(onSubmit)}>
      <div className="left">
        <div className="overlay">
          <h1>Hello World.</h1>
          <p>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur
            et est sed felis aliquet sollicitudin
          </p>
        </div>
      </div>
      <div className="right">
        <h5>Login</h5>
        <div className="inputs">
          <TextField
            variant="standard"
            fullWidth
            {...customRefNameRegister(register, "login")}
            type="text"
            placeholder="user name"
          />
          <br />
          <TextField
            variant="standard"
            fullWidth
            {...customRefNameRegister(register, "password")}
            type="password"
            placeholder="password"
          />
        </div>
        <br />
        <button type="submit">Login</button>
        <Collapse in={isErrorVisible}>
          <Alert severity="error">Nieprawidłowy login lub hasło</Alert>
        </Collapse>
      </div>
    </form>
  );
};
export default SignIn;
