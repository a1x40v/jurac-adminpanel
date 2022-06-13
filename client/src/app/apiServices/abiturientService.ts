import dateFormat from 'dateformat';

import {
  Abiturient,
  AbiturientListVm,
  ExportedAbiturient,
} from '../models/Abiturient';
import { AbtFiltersState } from '../state/slices/abiturientSlice';
import { baseApi, CacheTagType } from './baseService';

interface GetAbiturientsParams {
  pageNumber: number;
  pageSize: number;
  orderBy?: string;
  filtering: AbtFiltersState;
}

export const abiturientApi = baseApi.injectEndpoints({
  endpoints: (builder) => ({
    getAbiturients: builder.query<AbiturientListVm, GetAbiturientsParams>({
      query: ({ pageNumber, pageSize, orderBy, filtering }) => ({
        url: 'users',
        params: {
          pageNumber,
          pageSize,
          orderBy,
          ...filtering,
        },
      }),
      providesTags: (result) =>
        result
          ? [
              ...result.users.map(
                ({ id }) => ({ id, type: CacheTagType.Abiturients } as const)
              ),
              { type: CacheTagType.Abiturients, id: 'PARTIAL-LIST' },
            ]
          : [{ type: CacheTagType.Abiturients, id: 'PARTIAL-LIST' }],
    }),
  }),
});

const transformToExported = ({
  id,
  firstName,
  lastName,
  patronymic,
  dateOfBirth,
  nameUz,
  address,
  snils,
}: Abiturient): ExportedAbiturient => ({
  id,
  firstName,
  lastName,
  patronymic,
  dateOfBirth,
  nameUz,
  address,
  snils,
});

export const exportAbiturients = (abs: Abiturient[]) => {
  const exported: ExportedAbiturient[] = abs.map(transformToExported);
  const fileName = `Export_${dateFormat(new Date(), 'hh-MM_dd-mm-yy')}.xlsx`;

  fetch('http://localhost:5285/api/users/export', {
    method: 'post',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({
      users: exported,
    }),
  })
    .then((resp) => resp.blob())
    .then((response) => {
      const url = window.URL.createObjectURL(new Blob([response]));
      const link = document.createElement('a');
      link.href = url;
      link.setAttribute('download', fileName);
      document.body.appendChild(link);
      link.click();
      document.body.removeChild(link);
    });
};

export const { useGetAbiturientsQuery } = abiturientApi;
