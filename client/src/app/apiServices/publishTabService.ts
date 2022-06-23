import { ChoiceProfile, ChoiceProfileSet } from '../models/ChoiceProfile';
import {
  PublishTab,
  PublishTabCreateModel,
  PublishTabUpdateModel,
  PublishTabView,
} from '../models/PublishTab';
import { baseApi, CacheTagType } from './baseService';

export const publishTabApi = baseApi.injectEndpoints({
  endpoints: (builder) => ({
    getPublishTabs: builder.query<PublishTabView[], void>({
      query: () => 'publishtabs',
      transformResponse: (rawResult: PublishTab[]) => {
        return rawResult.map(
          ({ id, userId, fullName, individualStr, testType, ...other }) => ({
            id,
            userId,
            fullName,
            individualStr,
            testType,
            profiles: publishProfilesToArray(other),
          })
        );
      },
      providesTags: (result) =>
        result
          ? [
              ...result.map(
                ({ userId }) =>
                  ({ id: userId, type: CacheTagType.PublishTabs } as const)
              ),
              { type: CacheTagType.PublishTabs, id: 'LIST' },
            ]
          : [{ type: CacheTagType.PublishTabs, id: 'LIST' }],
    }),
    getPublishTab: builder.query<PublishTab | null, number>({
      query: (userId) => `publishtabs/users/${userId}`,
      providesTags: (result, error, userId) => [
        { type: CacheTagType.PublishTabs, id: userId },
      ],
    }),
    createPublishTab: builder.mutation<void, PublishTabCreateModel>({
      query: (model) => ({
        url: `publishtabs`,
        method: 'POST',
        body: model,
      }),
      invalidatesTags: (result, error, { userId }) => [
        { type: CacheTagType.PublishTabs, id: userId },
        { type: CacheTagType.PublishTabs, id: 'LIST' },
      ],
    }),
    updatePublishTab: builder.mutation<void, PublishTabUpdateModel>({
      query: (model) => ({
        url: `publishtabs/users/${model.userId}`,
        method: 'PUT',
        body: model,
      }),
      invalidatesTags: (result, error, { userId }) => [
        { type: CacheTagType.PublishTabs, id: userId },
      ],
    }),
    deletePublishTab: builder.mutation<void, number>({
      query: (userId) => ({
        url: `publishtabs/users/${userId}`,
        method: 'DELETE',
      }),
      invalidatesTags: (result, error, userId) => [
        { type: CacheTagType.PublishTabs, id: userId },
      ],
    }),
  }),
});

export const {
  useGetPublishTabsQuery,
  useGetPublishTabQuery,
  useCreatePublishTabMutation,
  useUpdatePublishTabMutation,
  useDeletePublishTabMutation,
} = publishTabApi;

export const publishProfilesToArray = (
  profiles: ChoiceProfileSet
): ChoiceProfile[] => {
  const result: ChoiceProfile[] = [];

  Object.keys(ChoiceProfile).forEach((key) => {
    const lowerKey = (key.charAt(0).toLowerCase() +
      key.slice(1)) as keyof ChoiceProfileSet;
    if (profiles[lowerKey]) {
      const profile = ChoiceProfile[key as keyof typeof ChoiceProfile];
      if (profile) result.push(profile);
    }
  });

  return result;
};

export const publishProfilesToSet = (
  profiles: ChoiceProfile[]
): ChoiceProfileSet => {
  const result: Record<string, boolean> = {};

  Object.entries(ChoiceProfile).forEach(([key, val]) => {
    const lowerKey = key.charAt(0).toLowerCase() + key.slice(1);
    result[lowerKey] = profiles.includes(val);
  });

  // @ts-ignore
  return result as ChoiceProfileSet;
};
