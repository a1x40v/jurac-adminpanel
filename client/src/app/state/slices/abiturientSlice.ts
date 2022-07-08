import { createSlice, PayloadAction } from '@reduxjs/toolkit';

import {
  AbtSortableField,
  DocExistStatus,
  DocSendStatus,
} from '../../models/Abiturient';
import { SortingValue } from '../../models/Sorting';

export interface AbtFiltersState {
  minDateJoined?: string;
  maxDateJoined?: string;
  docExistStatus?: DocExistStatus;
  docStatuses: DocSendStatus[];
}

interface AbiturientState {
  currentPage: number;
  totalPages?: number;
  pageSize: number;
  sorting: SortingValue<AbtSortableField>[];
  filtering: AbtFiltersState;
  search?: string;
}

const initialState: AbiturientState = {
  currentPage: 1,
  totalPages: undefined,
  pageSize: 10,
  sorting: [],
  filtering: {
    docStatuses: [],
  },
};

const slice = createSlice({
  name: 'abiturient',
  initialState,
  reducers: {
    changeCurrentPage: (state, { payload }: PayloadAction<number>) => {
      state.currentPage = payload;
    },
    changeTotalPages: (state, { payload }: PayloadAction<number>) => {
      state.totalPages = payload;
    },
    changePageSize: (state, { payload }: PayloadAction<number>) => {
      state.pageSize = payload;
    },
    addSorting: (state, { payload }: PayloadAction<AbtSortableField>) => {
      const idx = state.sorting.findIndex((x) => x.field === payload);

      if (idx === 0) return;

      const newVal =
        idx > 0
          ? { field: payload, isDesc: state.sorting[idx].isDesc }
          : { field: payload, isDesc: false };

      state.sorting = [newVal, ...state.sorting.slice(0, 1)];
    },
    toggleSorting: (state, { payload }: PayloadAction<AbtSortableField>) => {
      const idx = state.sorting.findIndex((x) => x.field === payload);

      if (idx > -1) {
        state.sorting[idx].isDesc = !state.sorting[idx].isDesc;
      }
    },
    removeSorting: (state, { payload }: PayloadAction<AbtSortableField>) => {
      if (state.sorting.some((x) => x.field === payload)) {
        state.sorting = state.sorting.filter((x) => x.field !== payload);
      }
    },
    changeFiltering: (state, { payload }: PayloadAction<AbtFiltersState>) => {
      state.filtering.maxDateJoined = payload.maxDateJoined;
      state.filtering.minDateJoined = payload.minDateJoined;
      state.filtering.docStatuses = [...payload.docStatuses];
      state.filtering.docExistStatus = payload.docExistStatus;
    },
    changeSearch: (state, { payload }: PayloadAction<string | undefined>) => {
      state.search = payload;
    },
  },
});

export const {
  changeCurrentPage,
  changePageSize,
  changeTotalPages,
  addSorting,
  toggleSorting,
  removeSorting,
  changeFiltering,
  changeSearch,
} = slice.actions;

export default slice.reducer;
