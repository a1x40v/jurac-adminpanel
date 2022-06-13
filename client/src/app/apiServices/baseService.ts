import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export enum CacheTagType {
  Abiturients = 'Abiturients',
}

export const baseApi = createApi({
  reducerPath: 'applicationApi',
  tagTypes: [CacheTagType.Abiturients],
  baseQuery: fetchBaseQuery({
    baseUrl: 'http://localhost:5285/api',
  }),
  endpoints: () => ({}),
});
