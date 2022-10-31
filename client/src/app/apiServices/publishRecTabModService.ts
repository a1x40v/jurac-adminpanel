import { PublishRecTabMod } from '../models/PublishRecTabMod';
import { baseApi, CacheTagType } from './baseService';

export const publishRecTabModService = baseApi.injectEndpoints({
  endpoints: (builder) => ({
    getPublishRecTabMods: builder.query<PublishRecTabMod[], void>({
      query: () => 'rectabmodifications',
      transformResponse: (rawResult: PublishRecTabMod[]) => {
        return rawResult.map((x) => {
          x.createdAt = x.createdAt.endsWith('Z')
            ? x.createdAt
            : `${x.createdAt}Z`;
          return x;
        });
      },
      providesTags: (result) =>
        result
          ? [
              ...result.map(
                ({ id }) =>
                  ({ id, type: CacheTagType.PublishRecTabMods } as const)
              ),
              { type: CacheTagType.PublishRecTabMods, id: 'LIST' },
            ]
          : [{ type: CacheTagType.PublishRecTabMods, id: 'LIST' }],
    }),
  }),
});

export const { useGetPublishRecTabModsQuery } = publishRecTabModService;
