import { Form, Formik } from 'formik';
import { ReactElement } from 'react';
import dateFormat from 'dateformat';

import { Abiturient, AbiturientUpdate } from '../../../app/models/Abiturient';
import FormikInputText from '../../common/UI/formik/FormikInputText';
import Button from '../../common/UI/inputs/Button';
import InputDate from '../../common/UI/inputs/InputDate';

interface Props {
  abitur: Abiturient;
}

const AbiturientForm: React.FC<Props> = ({ abitur }) => {
  const { documents, dateOfBirth, ...updatable } = abitur;
  const initialValues = {
    dateOfBirth: dateFormat(new Date(dateOfBirth), 'yyyy-mm-dd'),
    ...updatable,
  };

  const handleSubmit = async (values: AbiturientUpdate) => {
    console.log(new Date(values.dateOfBirth));
  };

  return (
    <Formik initialValues={initialValues} onSubmit={handleSubmit}>
      {({ isSubmitting, isValid, dirty, getFieldProps }) => (
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

const FormField: React.FC<{
  name: string;
  label: string | ReactElement;
  isFullWidth?: boolean;
}> = ({ name, label, isFullWidth }) => {
  return (
    <div className="flex items-center justify-between mb-6">
      <div className="mr-4">{label}:</div>
      <FormikInputText isFullWidth={isFullWidth} name={name} />
    </div>
  );
};

export default AbiturientForm;
