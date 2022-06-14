import { createSlice, PayloadAction } from '@reduxjs/toolkit';

import { Account } from '../../models/Account';

type AuthState = {
  account?: Account;
  token?: string;
};

const initialState: AuthState = {
  account: undefined,
  token: undefined,
};

const slice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    setCredentials: (
      state,
      {
        payload: { account, token },
      }: PayloadAction<{ account: Account; token: string }>
    ) => {
      state.account = account;
      state.token = token;
    },
    removeCredentials: (state) => {
      state.account = undefined;
      state.token = undefined;
    },
  },
});

export const { setCredentials, removeCredentials } = slice.actions;

export default slice.reducer;
