import { getMimeType } from '../../utils/apiUtils';
import {
  AbiturDocument,
  CreateDocumentModel,
  UpdateDocumentModel,
} from '../models/AbiturDocument';
import { baseApi, CacheTagType } from './baseService';

export const documentApi = baseApi.injectEndpoints({
  endpoints: (builder) => ({
    getDocument: builder.query<AbiturDocument, number>({
      query: (id) => `documents/${id}`,
      providesTags: (result, error, id) => [
        { type: CacheTagType.Documents, id },
      ],
    }),
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
      query: ({ userId, file, fileName, docType }) => {
        const data = new FormData();

        data.append('file', file);
        data.append('fileName', fileName);
        data.append('docType', docType);
        data.append('userId', `${userId}`);

        return {
          url: `documents/users/${userId}`,
          method: 'POST',
          body: data,
        };
      },
      invalidatesTags: (result, error, { userId }) => [
        { type: CacheTagType.Documents, id: userId },
        { type: CacheTagType.Documents, id: 'LIST' },
      ],
    }),
    updateDocument: builder.mutation<void, UpdateDocumentModel>({
      query: ({ id, fileName, file, docType }) => {
        const data = new FormData();
        data.append('docId', `${id}`);
        data.append('filename', fileName);
        data.append('docType', docType);
        if (file) data.append('file', file);

        return {
          url: `documents/${id}`,
          method: 'PUT',
          body: data,
        };
      },
      invalidatesTags: () => [CacheTagType.Documents],
    }),
    deleteDocument: builder.mutation<void, number>({
      query: (id) => {
        return {
          url: `documents/${id}`,
          method: 'DELETE',
        };
      },
      invalidatesTags: (result, error, id) => [
        { type: CacheTagType.Documents, id },
        { type: CacheTagType.Documents, id: 'LIST' },
      ],
    }),
  }),
});

export const openDocumentContent = (
  docId: number,
  fileName: string,
  jwtToken: string
): Promise<string> => {
  return fetch(`${process.env.REACT_APP_API_URL}/documents/${docId}/content`, {
    method: 'get',
    headers: {
      authorization: `Bearer ${jwtToken}`,
      'Content-Type': 'application/pdf',
    },
  })
    .then((resp) => resp.blob())
    .then((response) => {
      const mimeType = getMimeType(fileName) || 'application/octet-stream';
      const file = new Blob([response], { type: mimeType });
      const url = window.URL.createObjectURL(file);
      window.open(url, '_blank')!.focus();
      return url;
    });
};

export const {
  useGetDocumentQuery,
  useGetDocumentsForUserQuery,
  useCreateDocumentMutation,
  useUpdateDocumentMutation,
  useDeleteDocumentMutation,
} = documentApi;
