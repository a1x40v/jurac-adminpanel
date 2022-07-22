import { CreateDocumentModel, UpdateDocumentModel } from '../models/Document';
import { baseApi } from './baseService';

export const documentApi = baseApi.injectEndpoints({
  endpoints: (builder) => ({
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

export const { useCreateDocumentMutation, useUpdateDocumentMutation } =
  documentApi;
