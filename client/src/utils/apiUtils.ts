import { SortingValue } from '../app/models/Sorting';

export const getSortingString = (sorting: SortingValue<any>[]): string => {
  return sorting.reduce(
    (acc, { field, isDesc }, idx) =>
      `${acc}${idx > 0 ? ',' : ''}${field}${isDesc ? ' desc' : ''}`,
    ''
  );
};

const MAP_EXT_TO_MIME: { [key: string]: string } = {
  pdf: 'application/pdf',
  png: 'image/png',
  jpeg: 'image/jpeg',
  jpg: 'image/jpeg',
};

export const getMimeType = (fileName: string): string | null => {
  const arr = fileName.split('.');
  const ext = arr[arr.length - 1];

  return ext in MAP_EXT_TO_MIME ? MAP_EXT_TO_MIME[ext] : null;
};
