import { Account } from '../models/Account';
import { baseApi } from './baseService';

export interface LoginRequest {
  username: string;
  password: string;
}

export interface AuthenticateResponse {
  account: Account;
  jwtToken: string;
}

export const authApi = baseApi.injectEndpoints({
  endpoints: (builder) => ({
    login: builder.mutation<AuthenticateResponse, LoginRequest>({
      query: (credentials) => ({
        url: 'account/login',
        method: 'POST',
        body: credentials,
      }),
    }),
  }),
});

export const { useLoginMutation } = authApi;
