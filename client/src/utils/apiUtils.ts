import { SortingValue } from '../app/models/Sorting';

export const getSortingString = (sorting: SortingValue<any>[]): string => {
  return sorting.reduce(
    (acc, { field, isDesc }, idx) =>
      `${acc}${idx > 0 ? ',' : ''}${field}${isDesc ? ' desc' : ''}`,
    ''
  );
};
