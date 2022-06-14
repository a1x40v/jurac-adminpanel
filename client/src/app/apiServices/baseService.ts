import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

import { RootState } from '../state/store';

export enum CacheTagType {
  Abiturients = 'Abiturients',
}

export const baseApi = createApi({
  reducerPath: 'applicationApi',
  tagTypes: [CacheTagType.Abiturients],
  baseQuery: fetchBaseQuery({
    baseUrl: 'http://localhost:5285/api',
    prepareHeaders: (headers, { getState }) => {
      const token = (getState() as RootState).auth.token;
      if (token) {
        headers.set('authorization', `Bearer ${token}`);
      }
      return headers;
    },
  }),
  endpoints: () => ({}),
});
