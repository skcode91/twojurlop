import dynamic from "next/dynamic";

const VacationRequests = dynamic(
  () => import("src/components/dashboard/vacation-requests/VacationRequests"),
  {
    ssr: false,
  }
);

export default VacationRequests;
