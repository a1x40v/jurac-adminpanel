import {
  PublishRecTab,
  PublishRecTabCreateModel,
  PublishRecTabUpdateModel,
  PublishRecTabView,
} from '../models/PublishRecTab';
import { baseApi, CacheTagType } from './baseService';
import { publishProfilesToArray } from './publishTabService';

export const publishRecTabApi = baseApi.injectEndpoints({
  endpoints: (builder) => ({
    getPublishRecTabs: builder.query<PublishRecTabView[], void>({
      query: () => 'publishrectabs',
      transformResponse: (rawResult: PublishRecTab[]) => {
        return rawResult.map(
          ({
            id,
            userId,
            fullName,
            testType,
            sogl,
            sostType,
            advantage,
            sumPoints,
            isPublished,
            comment,
            ...other
          }) => ({
            id,
            userId,
            fullName,
            testType,
            sogl,
            sostType,
            advantage,
            sumPoints,
            isPublished,
            comment,
            profiles: publishProfilesToArray(other),
          })
        );
      },
      providesTags: (result) =>
        result
          ? [
              ...result.map(
                ({ userId }) =>
                  ({ id: userId, type: CacheTagType.PublishRecTabs } as const)
              ),
              { type: CacheTagType.PublishRecTabs, id: 'LIST' },
            ]
          : [{ type: CacheTagType.PublishRecTabs, id: 'LIST' }],
    }),
    getPublishRecTab: builder.query<PublishRecTab | null, number>({
      query: (userId) => `publishrectabs/users/${userId}`,
      providesTags: (result, error, userId) => [
        { type: CacheTagType.PublishRecTabs, id: userId },
      ],
    }),
    createPublishRecTab: builder.mutation<void, PublishRecTabCreateModel>({
      query: (model) => ({
        url: `publishrectabs`,
        method: 'POST',
        body: model,
      }),
      invalidatesTags: (result, error, { userId }) => [
        { type: CacheTagType.PublishRecTabs, id: userId },
        { type: CacheTagType.PublishRecTabs, id: 'LIST' },
        { type: CacheTagType.PublishRecTabMods, id: 'LIST' },
      ],
    }),
    updatePublishRecTab: builder.mutation<void, PublishRecTabUpdateModel>({
      query: (model) => ({
        url: `publishrectabs/users/${model.userId}`,
        method: 'PUT',
        body: model,
      }),
      invalidatesTags: (result, error, { userId }) => [
        { type: CacheTagType.PublishRecTabs, id: userId },
        { type: CacheTagType.PublishRecTabMods, id: 'LIST' },
      ],
    }),
    deletePublishRecTab: builder.mutation<void, number>({
      query: (userId) => ({
        url: `publishrectabs/users/${userId}`,
        method: 'DELETE',
      }),
      invalidatesTags: (result, error, userId) => [
        { type: CacheTagType.PublishRecTabs, id: userId },
        { type: CacheTagType.PublishRecTabMods, id: 'LIST' },
      ],
    }),
    deployPublishRecTabs: builder.mutation<void, void>({
      query: () => ({
        url: 'publishrectabs/deploy',
        method: 'POST',
      }),
      invalidatesTags: () => [
        { type: CacheTagType.PublishRecTabMods, id: 'LIST' },
      ],
    }),
  }),
});

export const {
  useGetPublishRecTabsQuery,
  useGetPublishRecTabQuery,
  useCreatePublishRecTabMutation,
  useUpdatePublishRecTabMutation,
  useDeletePublishRecTabMutation,
  useDeployPublishRecTabsMutation,
} = publishRecTabApi;
