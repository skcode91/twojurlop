import dynamic from "next/dynamic";

const SignIn = dynamic(() => import("src/components/sign-in/SignIn"), {
  ssr: false,
});

export default SignIn;
