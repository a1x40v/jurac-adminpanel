import { Form, Formik } from 'formik';
import * as Yup from 'yup';

import {
  CHOICE_PROFILES,
  TEST_TYPES,
} from '../../../app/constants/abiturientConstants';
import { ChoiceProfile } from '../../../app/models/ChoiceProfile';
import FormikInputText from '../../common/UI/formik/FormikInputText';
import Button from '../../common/UI/inputs/Button';
import InputSelect, { SelectOption } from '../../common/UI/inputs/InputSelect';
import { AbiturientTestType } from '../../../app/models/Abiturient';

interface Props {
  values: PublishTabFormValues;
  onSubmit: (values: PublishTabFormValues) => void;
}

export interface PublishTabFormValues {
  id?: number;
  userId: number;
  individualStr: string;
  testType: AbiturientTestType;
  profiles: ChoiceProfile[];
}

const profileOptions = CHOICE_PROFILES.map((value) => ({
  value,
  label: value,
}));

const testTypeOptions = TEST_TYPES.map((value) => ({
  value,
  label: value,
}));

const validationSchema = Yup.object({
  individualStr: Yup.string()
    .required('обязательное поле')
    .matches(/^\d+\/\d+$/, 'неправильный формат ввода'),
});

const PublishTabForm: React.FC<Props> = ({ values, onSubmit }) => {
  const isExisting = Boolean(values.id);

  const defaultProfilesOptions = values.profiles.map((value: string) => ({
    value,
    label: value,
  }));

  return (
    <Formik
      initialValues={values}
      validationSchema={validationSchema}
      onSubmit={onSubmit}
      enableReinitialize={true}
    >
      {({ isSubmitting, isValid, dirty, setFieldValue, getFieldProps }) => (
        <Form>
          <div className="flex flex-col items-start">
            <div className="flex flex-col mb-6">
              <div className="mb-2">Поток/Год:</div>
              <FormikInputText name={'individualStr'} />
            </div>

            <div className="flex flex-col mb-6">
              <span className="mb-2">Тип вступительных испытаний:</span>
              <InputSelect
                options={testTypeOptions}
                defaultValue={{
                  value: values.testType,
                  label: values.testType,
                }}
                onChange={(val) => {
                  setFieldValue('testType', val);
                }}
              />
            </div>

            <div className="mb-6">
              <p className="mb-2">Формы обучения:</p>
              <InputSelect
                isMulti
                menuPlacement="top"
                options={profileOptions}
                menuWidth="600px"
                defaultValue={defaultProfilesOptions}
                onChange={(vals) => {
                  const newOpts = vals as SelectOption<ChoiceProfile>[];
                  setFieldValue(
                    'profiles',
                    newOpts.map(({ value }) => value)
                  );
                }}
              />
            </div>

            <Button
              type="submit"
              label={
                isSubmitting
                  ? 'Загрузка...'
                  : isExisting
                  ? 'Обновить'
                  : 'Создать'
              }
              disabled={isSubmitting || !isValid || !dirty}
            />
          </div>
        </Form>
      )}
    </Formik>
  );
};

export default PublishTabForm;
