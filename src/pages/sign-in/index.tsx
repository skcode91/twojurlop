import React from "react";

const SignIn = () => {
  return (
    <div className="box-form">
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
          <input type="text" placeholder="user name" />
          <br />
          <input type="password" placeholder="password" />
        </div>
        <br />
        <button>Login</button>
      </div>
    </div>
  );
};
export default SignIn;
