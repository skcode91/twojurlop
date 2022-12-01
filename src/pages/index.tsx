import Head from "next/head";
import { useRouter } from "next/router";
import { useCallback, useEffect } from "react";
import { Pages } from "src/common/enums/Pages";
import { getPageUrl } from "src/common/helpers/routingHelper";

export default function Home() {
  const router = useRouter();

  const redirectToSignIn = useCallback(
    async () => await router.push(getPageUrl(Pages.signIn)),
    [router]
  );

  useEffect(() => {
    redirectToSignIn();
  }, [redirectToSignIn]);

  return (
    <div>
      <Head>
        <meta name="description" content="Generated by create next app" />
        <link rel="icon" href="/favicon.ico" />
        <title>Twój Urlop</title>
        <link
          href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"
          rel="stylesheet"
          integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN"
        />
      </Head>
    </div>
  );
}
