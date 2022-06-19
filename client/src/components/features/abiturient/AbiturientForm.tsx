import dateFormat from 'dateformat';
import { Form, Formik } from 'formik';

import {
  CHOICE_PROFILES,
  SEND_STATUSES,
  SEND_STATUS_DESC,
} from '../../../app/constants/abiturientConstants';
import {
  AbiturDocument,
  Abiturient,
  AbiturientUpdate,
} from '../../../app/models/Abiturient';
import { ChoiceProfile } from '../../../app/models/ChoiceProfile';
import DropwdownMenu from '../../common/layout/DropwdownMenu';
import FormField from '../../common/UI/formik/FormField';
import Button from '../../common/UI/inputs/Button';
import InputDate from '../../common/UI/inputs/InputDate';
import InputSelect, { SelectOption } from '../../common/UI/inputs/InputSelect';

interface Props {
  abitur: Abiturient;
  onSubmit: (updated: AbiturientUpdate) => void;
}

const profileOptions = CHOICE_PROFILES.map((value) => ({
  value,
  label: value,
}));

const statusOptions = SEND_STATUSES.map((value) => ({
  value,
  label: SEND_STATUS_DESC[value],
}));

const AbiturientForm: React.FC<Props> = ({ abitur, onSubmit }) => {
  const { documents, lastLogin, dateJoined, ...updatable } = abitur;
  const initialValues = updatable;

  return (
    <Formik initialValues={initialValues} onSubmit={onSubmit}>
      {({ isSubmitting, isValid, dirty, setFieldValue, getFieldProps }) => (
        <Form>
          <div className="flex flex-col items-start">
            <div className="flex justify-between w-full">
              <div className="flex flex-col">
                <FormField name="firstName" label="Имя" />
                <FormField name="lastName" label="Фамилия" />
                <FormField name="patronymic" label="Отчество" />
              </div>
              <div className="flex flex-col">
                <FormField name="phoneNumber" label="Номер телефона" />
                <FormField name="passport" label="Паспортные данные" />
                <FormField name="snils" label="Снилс" />
              </div>
              <div className="flex flex-col">
                <div className="flex items-center justify-between mb-6">
                  <div className="mr-4">Дата рождения:</div>
                  <InputDate {...getFieldProps('dateOfBirth')} />
                </div>
              </div>
            </div>

            <div className="flex flex-col mt-8 w-[100%]">
              <FormField isFullWidth={true} name="email" label="Email" />
              <FormField
                isFullWidth={true}
                name="address"
                label="Адрес регистрации (по паспорту)"
              />
              <FormField
                isFullWidth={true}
                name="nameUz"
                label={
                  <span>
                    Наименование учебного заведения,
                    <br /> которое окончил(а)
                  </span>
                }
              />
              <FormField
                isFullWidth={true}
                name="dateOfDoc"
                label={
                  <span>
                    Дата выдачи документа об образовании
                    <br /> в формате ДД.ММ.ГГГГ
                  </span>
                }
              />
              <FormField
                isFullWidth={true}
                name="commentAdmin"
                label="Комментарий для внутренней работы"
              />
            </div>

            <div className="flex my-8">
              <div className="flex flex-col min-w-[200px] mr-20">
                <span className="mb-2">Статус заявки:</span>
                <InputSelect
                  menuPlacement="top"
                  options={statusOptions}
                  defaultValue={{
                    value: getFieldProps('sendingStatus').value,

                    label:
                      // @ts-ignore
                      SEND_STATUS_DESC[getFieldProps('sendingStatus').value],
                  }}
                  onChange={(val) => {
                    setFieldValue('sendingStatus', val);
                  }}
                />
              </div>

              <div className="flex flex-col">
                <label className="flex items-center mb-6 cursor-pointer">
                  <div className="mr-4 min-w-[200px]">
                    Документы отправлены:
                  </div>
                  <input
                    type="checkbox"
                    checked={getFieldProps('completeFlag').value}
                    {...getFieldProps('completeFlag')}
                  />
                </label>

                <label className="flex items-center mb-6 cursor-pointer">
                  <div className="mr-4 min-w-[200px]">Соглашение:</div>
                  <input
                    type="checkbox"
                    className="grow"
                    checked={getFieldProps('agreementFlag').value}
                    {...getFieldProps('agreementFlag')}
                  />
                </label>

                <label className="flex items-center mb-6 cursor-pointer">
                  <div className="mr-4 min-w-[200px]">Взят в работу:</div>
                  <input
                    type="checkbox"
                    checked={getFieldProps('workFlag').value}
                    {...getFieldProps('workFlag')}
                  />
                </label>

                <label className="flex items-center mb-6 cursor-pointer">
                  <div className="mr-4 min-w-[200px]">Отработан:</div>
                  <input
                    type="checkbox"
                    checked={getFieldProps('successFlag').value}
                    {...getFieldProps('successFlag')}
                  />
                </label>
              </div>
            </div>

            <div className="mb-6">
              <p className="mb-2">Форма обучения:</p>
              <InputSelect
                isMulti
                options={profileOptions}
                menuWidth="600px"
                menuPlacement="top"
                defaultValue={getFieldProps('choicesProfiles').value.map(
                  (value: string) => ({ value, label: value })
                )}
                onChange={(vals) => {
                  const newOpts = vals as SelectOption<ChoiceProfile>[];
                  setFieldValue(
                    'choicesProfiles',
                    newOpts.map(({ value }) => value)
                  );
                }}
              />
            </div>

            <div className="mb-6">
              <DropwdownMenu
                label={`Документы (${
                  documents.length ? `${documents.length} шт.` : 'отсутствуют'
                }):`}
              >
                {documents.length ? (
                  <ul>
                    {documents.map((doc: AbiturDocument, idx) => (
                      <li key={doc.id} className="mb-1">
                        <p>
                          {idx + 1}. {doc.doc}
                        </p>
                        <p className="pl-5">
                          Подан:{' '}
                          {dateFormat(new Date(doc.datePub), 'dd.mm.yy hh:MM')}
                        </p>
                      </li>
                    ))}
                  </ul>
                ) : (
                  <p>Документы отсутствуют</p>
                )}
              </DropwdownMenu>
            </div>

            <Button
              type="submit"
              label="Отправить"
              disabled={isSubmitting || !isValid || !dirty}
            />
          </div>
        </Form>
      )}
    </Formik>
  );
};

export default AbiturientForm;
