import dynamic from "next/dynamic";

const Vacations = dynamic(
  () => import("src/components/dashboard/vacations/Vacations"),
  {
    ssr: false,
  }
);

export default Vacations;
