import { useMemo } from 'react';
import { TableInstance } from 'react-table';

import InputSelect from '../UI/inputs/InputSelect';
import PaginationButton from '../UI/pagination/PaginationButton';

interface Props {
  tableInstance: TableInstance;
  pageSizes?: number[];
}

interface PageSizeOption {
  value: number;
  label: string;
}

const DEFAULT_PAGE_SIZES = [10, 25, 50, 100];
const MAX_NUMBERS_AMOUNT = 7;

const PaginationBar: React.FC<Props> = ({ tableInstance, pageSizes }) => {
  const {
    canPreviousPage,
    canNextPage,
    pageCount,
    nextPage,
    previousPage,
    gotoPage,
    setPageSize,
    state: { pageIndex, pageSize },
  } = tableInstance;

  const pageSizeOptions: PageSizeOption[] = useMemo(
    () =>
      (pageSizes || DEFAULT_PAGE_SIZES).map((value) => ({
        value,
        label: `${value}`,
      })),
    [pageSizes]
  );

  if (pageCount <= 0) return null;

  const numbersAmount = Math.min(MAX_NUMBERS_AMOUNT, pageCount);
  const startNumber = pageIndex + 1 - Math.ceil(MAX_NUMBERS_AMOUNT / 2);
  let currentNumber = startNumber;
  const numbers: number[] = [];

  while (numbers.length < numbersAmount) {
    if (currentNumber >= 0) numbers.push(currentNumber);
    currentNumber++;
  }

  return (
    <div className="flex items-center justify-between">
      <ul className="flex border border-gray-300 divide-x divide-gray-300 space-x-[0px]">
        <li>
          <PaginationButton
            label="<"
            isDisabled={!canPreviousPage}
            onClick={previousPage}
          />
        </li>
        {numbers.map((pageIdx) => (
          <li key={pageIdx}>
            <PaginationButton
              label={`${pageIdx + 1}`}
              isActive={pageIdx === pageIndex}
              isDisabled={pageIdx === pageIndex}
              onClick={() => gotoPage(pageIdx)}
            />
          </li>
        ))}
        <li>
          <PaginationButton
            label=">"
            isDisabled={!canNextPage}
            onClick={nextPage}
          />
        </li>
      </ul>
      <div className="flex items-center space-x-2">
        <span>Размер страницы:</span>
        <InputSelect
          menuPlacement="top"
          options={pageSizeOptions}
          defaultValue={{ value: pageSize, label: `${pageSize}` }}
          onChange={(val) => setPageSize(Number(val))}
        />
      </div>
    </div>
  );
};

export default PaginationBar;
