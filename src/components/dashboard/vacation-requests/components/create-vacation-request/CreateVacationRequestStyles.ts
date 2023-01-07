import styled from "@emotion/styled";
import { Collapse, Paper } from "@mui/material";

export const CvrMainContainer = styled.div`
  display: flex;
  flex-direction: column;
  gap: 24px;
`;

export const CvrFormContainer = styled(Paper)`
  display: flex;
  flex-direction: column;
  gap: 24px;
  background: #1dcaff;
  margin: 12px 0;
  padding: 24px;
  & > div {
    display: flex;
    flex-direction: column;
    gap: 6px;
  }
  & > * > div {
    display: flex;
    flex-direction: column;
    gap: 6px;
  }
`;
