import { Form, Formik, FormikErrors } from 'formik';
import { useMemo } from 'react';

import { SEND_STATUS_DESC } from '../../../app/constants/abiturientConstants';
import { useAppDispatch, useAppSelector } from '../../../app/hooks/stateHooks';
import { DocSendStatus } from '../../../app/models/Abiturient';
import {
  changeFiltering,
  changeSearch,
} from '../../../app/state/slices/abiturientSlice';
import { removeTime } from '../../../utils/datetimeUtils';
import DropwdownMenu from '../../common/layout/DropwdownMenu';
import Button from '../../common/UI/inputs/Button';
import InputDate from '../../common/UI/inputs/InputDate';
import InputSelect, { SelectOption } from '../../common/UI/inputs/InputSelect';
import InputText from '../../common/UI/inputs/InputText';

interface FormValues {
  minJoined: string;
  maxJoined: string;
  statuses: DocSendStatus[];
  searching: string;
}

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
  const {
    filtering: { minDateJoined, maxDateJoined, docStatuses },
    search,
  } = useAppSelector((state) => state.abiturient);

  const initialValues: FormValues = {
    minJoined: minDateJoined || '',
    maxJoined: maxDateJoined || '',
    statuses: docStatuses,
    searching: search || '',
  };

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

  const handleApplyFilters = async (values: FormValues) => {
    const { minJoined, maxJoined, searching, statuses } = values;
    dispatch(
      changeFiltering({
        minDateJoined: minJoined || undefined,
        maxDateJoined: maxJoined || undefined,
        docStatuses: statuses,
      })
    );
    dispatch(changeSearch(searching || undefined));
  };

  const dropDownLabel = (
    <div className="flex">
      <span className="mr-6">
        {'Используемые фильтры: '}
        <span className="font-bold underline">
          {appliedFilters.length ? appliedFilters.join(', ') : 'отсутствуют'}
        </span>
      </span>
      <span>
        {'Поисковая строка: '}
        <span className="font-bold underline">
          {search ? search : 'отсутствует'}
        </span>
      </span>
    </div>
  );

  const validate = (values: FormValues): FormikErrors<FormValues> => {
    const { minJoined, maxJoined } = values;
    const errors: FormikErrors<FormValues> = {};

    if (minJoined && maxJoined) {
      if (new Date(minJoined) >= new Date(maxJoined)) {
        errors.maxJoined = 'Минимальная дата должна быть меньше максимальной.';
      }
    }

    if (minJoined) {
      if (
        removeTime(new Date(minJoined)).getTime() >
        removeTime(new Date()).getTime()
      ) {
        errors.minJoined =
          'Минимальная дата должна быть меньше сегодняшнего числа.';
      }
    }

    return errors;
  };

  return (
    <Formik
      initialValues={initialValues}
      validate={validate}
      onSubmit={handleApplyFilters}
    >
      {({
        errors,
        dirty,
        isSubmitting,
        isValid,
        getFieldProps,
        setFieldValue,
      }) => (
        <Form>
          <div>
            <DropwdownMenu label={dropDownLabel}>
              <div className="flex font-nanito mt-3">
                <div className="relative flex flex-col p-5 border-t border-sky-700">
                  <div className="absolute top-0 left-[50%] px-1 bg-white -translate-y-[60%] -translate-x-[50%]">
                    Дата&nbsp;регистрации
                  </div>
                  <div className="relative flex items-center justify-between min-w-[250px] pr-7">
                    <span>От:</span>
                    <InputDate {...getFieldProps('minJoined')} />
                    {getFieldProps('minJoined').value && (
                      <button
                        className="absolute right-0 p-2"
                        onClick={() => setFieldValue('minJoined', '')}
                      >
                        x
                      </button>
                    )}
                  </div>
                  <div className="relative flex items-center justify-between min-w-[250px] mt-1 pr-7">
                    <span>До:</span>
                    <InputDate {...getFieldProps('maxJoined')} />
                    {getFieldProps('maxJoined').value && (
                      <button
                        className="absolute right-0 p-2"
                        onClick={() => setFieldValue('maxJoined', '')}
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
                        getFieldProps('statuses').value.includes(value)
                      )}
                      onChange={(vals) => {
                        const newOpts = vals as SelectOption<DocSendStatus>[];
                        setFieldValue(
                          'statuses',
                          newOpts.map(({ value }) => value)
                        );
                      }}
                    />
                  </div>
                </div>

                <div className="relative flex flex-col justify-center min-w-[300px] p-5 border-t ml-7 border-sky-700">
                  <div className="absolute top-0 left-[50%] px-1 bg-white -translate-y-[60%] -translate-x-[50%]">
                    Поиск
                  </div>
                  <div>
                    <InputText {...getFieldProps('searching')} />
                  </div>
                </div>

                <div className="flex flex-col justify-center ml-7">
                  <Button
                    type="submit"
                    label="Применить"
                    disabled={isSubmitting || !isValid || !dirty}
                    isRounded
                  />
                </div>

                {Object.keys(errors).length ? (
                  <div className="ml-4 text-red-700">
                    <div className="text-center">Ошибки валидации:</div>
                    <ul>
                      {Object.values(errors).map((err) => (
                        <li key={err.toString()}>- {err}</li>
                      ))}
                    </ul>
                  </div>
                ) : null}
              </div>
            </DropwdownMenu>
          </div>
        </Form>
      )}
    </Formik>
  );
};

export default AbiturientFilters;
