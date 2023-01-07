import styled from "@emotion/styled";
import { MenuItem, Paper } from "@mui/material";

export const SbMainContainer = styled(Paper)`
  margin-top: 16px;
  height: calc(100vh - 64px - 64px);
  width: 20%;
  min-width: 200px;
  background: lightskyblue;
  padding: 24px 0;
  display: flex;
  flex-direction: column;
  align-items: center;
  border-radius: 8px;
`;

export const SbMenuContainer = styled.div`
  display: flex;
  flex-direction: column;
  width: 100%;
`;

export const SbMenuItem = styled(MenuItem)`
  &:hover {
    color: white;
    background: darkslateblue;
  }
  &.Mui-selected {
    background: blue;
    color: white;
  }
  &.Mui-selected:hover {
    background: darkslateblue;
    color: lightgray;
  }
`;
