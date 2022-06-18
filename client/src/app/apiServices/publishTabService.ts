import { ChoiceProfile, ChoiceProfileSet } from '../models/ChoiceProfile';
import { PublishTab, PublishTabView } from '../models/PublishTab';
import { baseApi } from './baseService';

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
    }),
  }),
});

export const { useGetPublishTabsQuery } = publishTabApi;

const publishProfilesToArray = (
  profiles: ChoiceProfileSet
): ChoiceProfile[] => {
  const result: ChoiceProfile[] = [];

  Object.entries(profiles).forEach(([key, value]) => {
    if (value) {
      const upperKey = key.charAt(0).toUpperCase() + key.slice(1);
      result.push(ChoiceProfile[upperKey as keyof typeof ChoiceProfile]);
    }
  });

  return result;
};
