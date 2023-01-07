import React, { SetStateAction } from "react";
import { HandleVacationRequestRequest } from "src/common/models/api/requests/HandleVacationRequestRequest";
import { VacationRequestDto } from "src/common/models/dto/VacationRequestDto";

export interface VacationRequestListProps {
  vacationRequests: VacationRequestDto[] | undefined;
  handleDelete: (request: VacationRequestDto) => void;
  year: number;
  setYear: (year: number) => void;
  handleVacationRequest: (request: HandleVacationRequestRequest) => void;
}
