import dynamic from "next/dynamic";

const Users = dynamic(() => import("src/components/dashboard/users/Users"), {
  ssr: false,
});

export default Users;
