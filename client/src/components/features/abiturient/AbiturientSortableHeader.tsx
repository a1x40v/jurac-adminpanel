import { CSSProperties } from 'react';

import { useAppDispatch, useAppSelector } from '../../../app/hooks/stateHooks';
import { AbtSortableField } from '../../../app/models/Abiturient';
import {
  addSorting,
  toggleSorting,
  removeSorting,
} from '../../../app/state/slices/abiturientSlice';

interface Props {
  field: AbtSortableField;
  title: string;
  styles?: CSSProperties;
}

const AbiturientSortableHeader: React.FC<Props> = ({
  field,
  title,
  styles = {},
}) => {
  const dispatch = useAppDispatch();
  const sorting = useAppSelector((state) => state.abiturient.sorting);
  const index = sorting.findIndex((x) => x.field === field);

  let sortingBar: React.ReactNode = null;

  const isSorted = index > -1;
  const isFirstSort = index === 0;

  if (isSorted) {
    const { isDesc } = sorting[index];
    sortingBar = (
      <div className="absolute top-0 right-0 flex items-center justify-around w-12">
        <span onClick={() => dispatch(toggleSorting(field))}>
          <div
            className={`border-solid border-x-transparent border-x-8 cursor-pointer ${
              isDesc ? 'border-t-white border-t-8' : 'border-b-white border-b-8'
            }`}
          ></div>
        </span>
        <span className="text-sm">{index + 1}</span>
        <button onClick={() => dispatch(removeSorting(field))}>x</button>
      </div>
    );
  }

  return (
    <div className="flex" style={styles}>
      <div className={`relative pr-14`}>
        <button
          className={`${isFirstSort ? '' : 'hover:underline'}`}
          disabled={isFirstSort}
          onClick={() => {
            dispatch(addSorting(field));
          }}
        >
          {title}
        </button>
        {sortingBar}
      </div>
    </div>
  );
};

export default AbiturientSortableHeader;
