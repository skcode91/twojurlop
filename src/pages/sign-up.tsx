import dynamic from "next/dynamic";

const SignUp = dynamic(() => import("src/components/sign-up/SignUp"), {
  ssr: false,
});

export default SignUp;
