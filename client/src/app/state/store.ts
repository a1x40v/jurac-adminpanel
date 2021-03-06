import { combineReducers, configureStore } from '@reduxjs/toolkit';
import storage from 'redux-persist/lib/storage';
import {
  persistReducer,
  FLUSH,
  REHYDRATE,
  PAUSE,
  PERSIST,
  PURGE,
  REGISTER,
} from 'redux-persist';

import { baseApi } from '../apiServices/baseService';
import abiturientReducer from './slices/abiturientSlice';
import authReducer from './slices/authSlice';

const rootPersistConfig = {
  key: 'root',
  whitelist: ['auth'],
  storage,
};

const abtrPersistConfig = {
  key: 'abiturient',
  blacklist: ['search'],
  storage,
};

const reducer = combineReducers({
  [baseApi.reducerPath]: baseApi.reducer,
  auth: authReducer,
  abiturient: persistReducer(abtrPersistConfig, abiturientReducer),
});

const persistedReducer = persistReducer(rootPersistConfig, reducer);

export const store = configureStore({
  reducer: persistedReducer,
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({
      serializableCheck: {
        ignoredActions: [FLUSH, REHYDRATE, PAUSE, PERSIST, PURGE, REGISTER],
      },
    }).concat(baseApi.middleware),
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
