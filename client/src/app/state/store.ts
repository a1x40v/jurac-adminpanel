import { configureStore } from '@reduxjs/toolkit';

import { baseApi } from '../apiServices/baseService';
import abiturientReducer from './slices/abiturientSlice';

export const store = configureStore({
  reducer: {
    [baseApi.reducerPath]: baseApi.reducer,
    abiturient: abiturientReducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(baseApi.middleware),
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
