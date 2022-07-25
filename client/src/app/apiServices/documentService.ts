import {
  AbiturDocument,
  CreateDocumentModel,
  UpdateDocumentModel,
} from '../models/AbiturDocument';
import { baseApi, CacheTagType } from './baseService';

export const documentApi = baseApi.injectEndpoints({
  endpoints: (builder) => ({
    getDocumentsForUser: builder.query<AbiturDocument[], number>({
      query: (userId) => `documents/users/${userId}`,
      providesTags: (result) =>
        result
          ? [
              ...result.map(
                ({ id }) => ({ id, type: CacheTagType.Documents } as const)
              ),
              { type: CacheTagType.Documents, id: 'LIST' },
            ]
          : [{ type: CacheTagType.Documents, id: 'LIST' }],
    }),
    createDocument: builder.mutation<void, CreateDocumentModel>({
      query: ({ userId, file }) => {
        const data = new FormData();
        data.append('file', file);

        return {
          url: `documents/users/${userId}`,
          method: 'POST',
          body: data,
        };
      },
    }),
    updateDocument: builder.mutation<void, UpdateDocumentModel>({
      query: ({ id }) => {
        return {
          url: `documents/${id}`,
          method: 'PUT',
        };
      },
    }),
  }),
});

export const {
  useCreateDocumentMutation,
  useUpdateDocumentMutation,
  useGetDocumentsForUserQuery,
} = documentApi;
