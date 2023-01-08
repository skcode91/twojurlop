import {
  Button,
  Collapse,
  IconButton,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
  Typography,
} from "@mui/material";
import React, { useState } from "react";
import { getRoleTranslation } from "src/common/helpers/translationHelper";
import { UsersListProps } from "./UsersListProps";
import { UlExpandedContainer, UlMainContainer } from "./UsersListStyles";
import ExpandLessIcon from "@mui/icons-material/ExpandLess";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import { getDisplayedDate } from "src/common/helpers/dateHelper";
import plLocale from "date-fns/locale/pl";
import { Roles } from "src/common/enums/Roles";

const UsersList = (props: UsersListProps) => {
  const { users, handleDeleteUser, handleChangeRole } = props;
  const [expandedUserId, setExpandedUserId] = useState<number | undefined>();

  return (
    <UlMainContainer>
      <Typography variant="h6">Lista pracowników</Typography>

      <Paper sx={{ background: "#1dcaff" }} elevation={12}>
        <Table
          sx={{ minWidth: 650, padding: "24px 0" }}
          aria-label="simple table"
        >
          <TableHead>
            <TableRow>
              <TableCell>Id</TableCell>
              <TableCell>Email</TableCell>
              <TableCell>Imię</TableCell>
              <TableCell>Nazwisko</TableCell>
              <TableCell>Rola</TableCell>
              <TableCell>Pesel</TableCell>
              <TableCell>Zatrudniony</TableCell>
              <TableCell>Akcje</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {users.map((row) => (
              <React.Fragment key={row.id}>
                <TableRow
                  sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
                >
                  <TableCell>{row.id}</TableCell>
                  <TableCell>{row.email}</TableCell>
                  <TableCell>{row.firstName}</TableCell>
                  <TableCell>{row.lastName}</TableCell>
                  <TableCell>{getRoleTranslation(row.roleId)}</TableCell>
                  <TableCell>{row.pesel ? row.pesel : ""}</TableCell>
                  <TableCell>
                    {getDisplayedDate(new Date(row.hiringDate), plLocale)}
                  </TableCell>
                  <TableCell>
                    {expandedUserId !== row.id ? (
                      <IconButton
                        onClick={() =>
                          setExpandedUserId(
                            expandedUserId === row.id ? undefined : row.id
                          )
                        }
                      >
                        <ExpandMoreIcon />
                      </IconButton>
                    ) : (
                      <IconButton
                        onClick={() =>
                          setExpandedUserId(
                            expandedUserId === row.id ? undefined : row.id
                          )
                        }
                      >
                        <ExpandLessIcon />
                      </IconButton>
                    )}
                  </TableCell>
                </TableRow>
                <TableRow>
                  <TableCell style={{ padding: 0 }} colSpan={10}>
                    <Collapse
                      in={expandedUserId === row.id}
                      timeout="auto"
                      unmountOnExit
                    >
                      <UlExpandedContainer>
                        <div style={{ width: "24px" }} />
                        <Button
                          variant="contained"
                          onClick={() => handleDeleteUser(row)}
                        >
                          Usuń konto
                        </Button>
                        <Button
                          variant="contained"
                          onClick={() => handleChangeRole(row, Roles.User)}
                        >
                          Ustaw rolę pracownik
                        </Button>
                        <Button
                          variant="contained"
                          onClick={() => handleChangeRole(row, Roles.Manager)}
                        >
                          Ustaw rolę manager
                        </Button>
                      </UlExpandedContainer>
                    </Collapse>
                  </TableCell>
                </TableRow>
              </React.Fragment>
            ))}
          </TableBody>
        </Table>
      </Paper>
    </UlMainContainer>
  );
};

export default UsersList;
