import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

import { RootState } from '../state/store';

export enum CacheTagType {
  Abiturients = 'Abiturients',
  PublishTabs = 'PublishTabs',
  PublishRecTabs = 'PublishRecTabs',
  PublishRecTabMods = 'PublishRecTabMods',
  EmailMessage = 'EmailMessage',
}

export const baseApi = createApi({
  reducerPath: 'applicationApi',
  tagTypes: [
    CacheTagType.Abiturients,
    CacheTagType.PublishTabs,
    CacheTagType.PublishRecTabs,
    CacheTagType.PublishRecTabMods,
    CacheTagType.EmailMessage,
  ],
  baseQuery: fetchBaseQuery({
    baseUrl: process.env.REACT_APP_API_URL,
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
