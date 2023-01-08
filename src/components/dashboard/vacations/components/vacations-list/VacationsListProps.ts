import { VacationDto } from "src/common/models/dto/VacationDto";

export interface VacationsListProps {
  vacations: VacationDto[];
  year: number;
  setYear: (year: number) => void;
}
