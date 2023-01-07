import dynamic from "next/dynamic";

const Dashboard = dynamic(() => import("src/components/dashboard/Dashboard"), {
  ssr: false,
});

export default Dashboard;
