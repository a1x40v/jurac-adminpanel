import React, { useEffect } from 'react';
import { Column, usePagination, useRowSelect, useTable } from 'react-table';
import { SiMicrosoftexcel } from 'react-icons/si';

import { exportAbiturients } from '../../../app/apiServices/abiturientService';
import { useAppDispatch, useAppSelector } from '../../../app/hooks/stateHooks';
import { Abiturient, AbiturientListVm } from '../../../app/models/Abiturient';
import {
  changeCurrentPage,
  changePageSize,
  changeTotalPages,
} from '../../../app/state/slices/abiturientSlice';
import ReactTable from '../../common/reactTable/ReactTable';
import PaginationBar from '../../common/reactTable/PaginationBar';

interface Props {
  columns: Array<Column>;
  data: AbiturientListVm;
}

const AbiturientTable: React.FC<Props> = ({ columns, data }) => {
  const dispatch = useAppDispatch();
  const {
    currentPage,
    pageSize: queryPageSize,
    totalPages,
  } = useAppSelector((state) => state.abiturient);

  const tableInstance = useTable(
    {
      columns,
      data: data.users,
      initialState: {
        pageIndex: currentPage - 1,
        pageSize: queryPageSize,
      },
      manualPagination: true,
      pageCount: data.pagination.totalPages,
    },
    usePagination,
    useRowSelect,
    (hooks) => {
      hooks.visibleColumns.push((columns) => [
        {
          id: 'selection',
          Header: ({ getToggleAllPageRowsSelectedProps }) => {
            const { indeterminate, ...props } =
              getToggleAllPageRowsSelectedProps();
            return (
              <div className="px-3">
                <input type="checkbox" {...props} />
              </div>
            );
          },
          Cell: ({ row }) => {
            const { indeterminate, ...props } = row.getToggleRowSelectedProps();
            return (
              <div className="px-3">
                <input type="checkbox" {...props} />
              </div>
            );
          },
        },
        ...columns,
      ]);
    }
  );

  const {
    gotoPage,
    selectedFlatRows,
    state: { pageIndex, pageSize },
  } = tableInstance;

  const isRowsSelected = selectedFlatRows.length > 0;

  useEffect(() => {
    if (!totalPages) {
      dispatch(changeTotalPages(data.pagination.totalPages));
    }
  }, [totalPages, data?.pagination.totalPages, dispatch]);

  useEffect(() => {
    dispatch(changePageSize(pageSize));
    gotoPage(0);
  }, [pageSize, gotoPage, dispatch]);

  useEffect(() => {
    dispatch(changeCurrentPage(pageIndex + 1));
  }, [pageIndex, dispatch]);

  return (
    <>
      <div className="relative flex items-start">
        <div>
          <ReactTable tableInstance={tableInstance} />
          <PaginationBar tableInstance={tableInstance} />
        </div>
        <div className="sticky mt-[50px] ml-5 top-20 text-sky-900 font-nanito">
          <div className="flex items-center justify-center w-[40px] h-[40px]">
            <button
              disabled={!isRowsSelected}
              onClick={() => {
                exportAbiturients(
                  selectedFlatRows.map((d) => d.original) as Abiturient[]
                );
              }}
            >
              <SiMicrosoftexcel
                className={`w-[30px] h-[30px] ${
                  isRowsSelected
                    ? 'text-sky-900 hover:text-sky-600 cursor-pointer'
                    : 'text-gray-600'
                }`}
              />
            </button>
          </div>
        </div>
      </div>
    </>
  );
};

export default AbiturientTable;
