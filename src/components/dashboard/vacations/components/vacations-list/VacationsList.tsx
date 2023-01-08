import {
  Button,
  Collapse,
  Paper,
  Stack,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
  TextField,
  Typography,
} from "@mui/material";
import React, { useState } from "react";
import { VacationsListProps } from "./VacationsListProps";
import plLocale from "date-fns/locale/pl";
import { getDisplayedDate } from "src/common/helpers/dateHelper";

const VacationsList = (props: VacationsListProps) => {
  const { vacations, year, setYear } = props;
  const [inputVal, setInputVal] = useState<number>(year);
  const [isEditYearVisible, setIsEditYearVisible] = useState(false);

  const handleChangeYear = (e: HTMLInputElement | HTMLTextAreaElement) => {
    const val = e.value;
    if (!isNaN(+val)) {
      setInputVal(parseInt(val));
    }
  };

  const acceptYear = () => {
    setYear(inputVal);
    setIsEditYearVisible(false);
  };

  return (
    <div>
      <Typography variant="h6">Lista próśb o urlop</Typography>
      <Stack display="flex" direction="row" padding="24px 0" gap="24px">
        <Typography variant="h6">Wybrany rok: {year}</Typography>
        <Button
          variant="contained"
          onClick={() => setIsEditYearVisible(!isEditYearVisible)}
        >
          Zmień
        </Button>
      </Stack>
      <Collapse in={isEditYearVisible}>
        <Stack display="flex" direction="column" padding="24px 0" gap="24px">
          <TextField
            value={inputVal}
            onChange={(e) => handleChangeYear(e.target)}
          />
          <Button variant="contained" onClick={() => acceptYear()}>
            Zastosuj
          </Button>
        </Stack>
      </Collapse>
      <Paper sx={{ background: "#1dcaff" }} elevation={12}>
        <Table
          sx={{ minWidth: 650, padding: "24px 0" }}
          aria-label="simple table"
        >
          <TableHead>
            <TableRow>
              <TableCell>Id</TableCell>
              <TableCell>Id pracownika</TableCell>
              <TableCell>Początek</TableCell>
              <TableCell>Koniec</TableCell>
              <TableCell>Liczba dni</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {vacations.map((row) => (
              <TableRow
                key={row.id}
                sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
              >
                <TableCell>{row.id}</TableCell>
                <TableCell>{row.userId}</TableCell>
                <TableCell>
                  {getDisplayedDate(new Date(row.startDate), plLocale)}
                </TableCell>
                <TableCell>
                  {getDisplayedDate(new Date(row.endDate), plLocale)}
                </TableCell>
                <TableCell>{row.daysCount}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </Paper>
    </div>
  );
};

export default VacationsList;
