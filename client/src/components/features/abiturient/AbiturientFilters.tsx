import { useMemo, useState } from 'react';

import { SEND_STATUS_DESC } from '../../../app/constants/abiturientConstants';
import { useAppDispatch, useAppSelector } from '../../../app/hooks/stateHooks';
import { DocSendStatus } from '../../../app/models/Abiturient';
import { changeFiltering } from '../../../app/state/slices/abiturientSlice';
import { removeTime } from '../../../utils/datetimeUtils';
import DropwdownMenu from '../../common/layout/DropwdownMenu';
import Button from '../../common/UI/inputs/Button';
import InputDate from '../../common/UI/inputs/InputDate';
import InputSelect, { SelectOption } from '../../common/UI/inputs/InputSelect';

interface DocStatusOption {
  value: DocSendStatus;
  label: string;
}

const options: DocStatusOption[] = [
  { value: DocSendStatus.Error, label: SEND_STATUS_DESC['error'] },
  { value: DocSendStatus.No, label: SEND_STATUS_DESC['no'] },
  { value: DocSendStatus.Send, label: SEND_STATUS_DESC['send'] },
  { value: DocSendStatus.Working, label: SEND_STATUS_DESC['working'] },
  { value: DocSendStatus.Success, label: SEND_STATUS_DESC['success'] },
  { value: DocSendStatus.Back, label: SEND_STATUS_DESC['back'] },
];

const AbiturientFilters = () => {
  const dispatch = useAppDispatch();
  const { minDateJoined, maxDateJoined, docStatuses } = useAppSelector(
    (state) => state.abiturient.filtering
  );

  const [minJoined, setMinJoined] = useState(minDateJoined);
  const [maxJoined, setMaxJoined] = useState(maxDateJoined);
  const [statuses, setStatuses] = useState(docStatuses);

  const isUntouched = useMemo(() => {
    const isDateUntouch =
      minDateJoined === minJoined && maxDateJoined === maxJoined;
    const isStatusesUntouch =
      statuses.length === docStatuses.length &&
      statuses.every((x) => docStatuses.includes(x));

    return isDateUntouch && isStatusesUntouch;
  }, [
    minDateJoined,
    maxDateJoined,
    docStatuses,
    minJoined,
    maxJoined,
    statuses,
  ]);

  const validationErrors: string[] = useMemo(() => {
    const result: string[] = [];

    if (minJoined && maxJoined) {
      if (new Date(minJoined) >= new Date(maxJoined)) {
        result.push('Минимальная дата должна быть меньше максимальной.');
      }
    }

    if (minJoined) {
      if (
        removeTime(new Date(minJoined)).getTime() >
        removeTime(new Date()).getTime()
      ) {
        result.push('Минимальная дата должна быть меньше сегодняшнего числа.');
      }
    }

    return result;
  }, [minJoined, maxJoined]);

  const appliedFilters: string[] = useMemo(() => {
    const result: string[] = [];

    if (minDateJoined || maxDateJoined) {
      result.push('дата регистации');
    }

    if (docStatuses.length) {
      result.push('статус документов');
    }

    return result;
  }, [minDateJoined, maxDateJoined, docStatuses]);

  const handleApplyFilters = () => {
    dispatch(
      changeFiltering({
        minDateJoined: minJoined,
        maxDateJoined: maxJoined,
        docStatuses: statuses,
      })
    );
  };

  return (
    <div className="mb-4">
      <DropwdownMenu
        label={`Используемые фильтры: ${
          appliedFilters.length ? appliedFilters.join(', ') : 'отсутствуют'
        }`}
      >
        <div className="flex font-nanito">
          <div className="relative flex flex-col p-5 border-t border-sky-700">
            <div className="absolute top-0 left-[50%] px-1 bg-white -translate-y-[60%] -translate-x-[50%]">
              Дата&nbsp;регистрации
            </div>
            <div className="relative flex items-center justify-between min-w-[250px] pr-7">
              <span>От:</span>
              <InputDate
                value={minJoined}
                onChange={(evt) => setMinJoined(evt.target.value)}
              />
              {minJoined && (
                <button
                  className="absolute right-0 p-2"
                  onClick={() => setMinJoined(undefined)}
                >
                  x
                </button>
              )}
            </div>
            <div className="relative flex items-center justify-between min-w-[250px] mt-1 pr-7">
              <span>До:</span>
              <InputDate
                value={maxJoined}
                onChange={(evt) => setMaxJoined(evt.target.value)}
              />
              {maxJoined && (
                <button
                  className="absolute right-0 p-2"
                  onClick={() => setMaxJoined(undefined)}
                >
                  x
                </button>
              )}
            </div>
          </div>

          <div className="relative flex flex-col justify-center min-w-[300px] p-5 border-t ml-7 border-sky-700">
            <div className="absolute top-0 left-[50%] px-1 bg-white -translate-y-[60%] -translate-x-[50%]">
              Статус&nbsp;документов
            </div>
            <div>
              <InputSelect
                isMulti
                options={options}
                defaultValue={options.filter(({ value }) =>
                  statuses.includes(value)
                )}
                onChange={(vals) => {
                  const newOpts = vals as SelectOption<DocSendStatus>[];
                  setStatuses(newOpts.map(({ value }) => value));
                }}
              />
            </div>
          </div>

          <div className="flex flex-col justify-center ml-7">
            <Button
              label="Применить"
              disabled={isUntouched || validationErrors.length > 0}
              isRounded
              onClick={handleApplyFilters}
            />
          </div>

          {validationErrors.length ? (
            <div className="ml-4 text-red-700">
              <div className="text-center">Ошибки валидации:</div>
              <ul>
                {validationErrors.map((err) => (
                  <li key={err}>- {err}</li>
                ))}
              </ul>
            </div>
          ) : null}
        </div>
      </DropwdownMenu>
    </div>
  );
};

export default AbiturientFilters;
