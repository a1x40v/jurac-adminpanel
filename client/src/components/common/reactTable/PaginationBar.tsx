import { TableInstance } from 'react-table';

import InputSelect from '../UI/inputs/InputSelect';
import PaginationButton from '../UI/pagination/PaginationButton';

interface Props {
  tableInstance: TableInstance;
}

interface PageSizeOption {
  value: number;
  label: string;
}

const options: PageSizeOption[] = [
  { value: 10, label: '10' },
  { value: 25, label: '25' },
  { value: 50, label: '50' },
  { value: 100, label: '100' },
];

const MAX_NUMBERS_AMOUNT = 7;

const PaginationBar: React.FC<Props> = ({ tableInstance }) => {
  const {
    canPreviousPage,
    canNextPage,
    pageCount,
    nextPage,
    previousPage,
    gotoPage,
    setPageSize,
    state: { pageIndex },
  } = tableInstance;

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
          options={options}
          defaultValue={options[0]}
          onChange={(val) => setPageSize(Number(val))}
        />
      </div>
    </div>
  );
};

export default PaginationBar;
