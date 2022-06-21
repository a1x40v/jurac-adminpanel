import { Form, Formik } from 'formik';
import {
  CHOICE_PROFILES,
  REC_ADVANTAGES,
  REC_SOGLS,
  REC_SOST_TYPES,
  TEST_TYPES,
} from '../../../app/constants/abiturientConstants';
import { AbiturientTestType } from '../../../app/models/Abiturient';
import { ChoiceProfile } from '../../../app/models/ChoiceProfile';
import { PublishRecTabPoints } from '../../../app/models/PublishRecTab';
import FormikInputText from '../../common/UI/formik/FormikInputText';
import Button from '../../common/UI/inputs/Button';
import InputSelect, { SelectOption } from '../../common/UI/inputs/InputSelect';

const calcSummPoints = (v: PublishRecTabFormValues): number =>
  v.individ +
  v.rusPoint +
  v.obshPoint +
  v.historyPoint +
  v.foreignLanguagePoint +
  v.gpPoint +
  v.tgpPoint +
  v.upPoint +
  v.kpPoint +
  v.okpPoint +
  v.specPoint;

interface Props {
  values: PublishRecTabFormValues;
  onSubmit: (values: PublishRecTabFormValues) => void;
}

export type PublishRecTabFormValues = {
  id?: number;
  userId: number;
  testType: AbiturientTestType;
  sogl: string;
  sostType: string;
  advantage: string;
  profiles: ChoiceProfile[];
} & Omit<PublishRecTabPoints, 'sumPoints'>;

const profileOptions = CHOICE_PROFILES.map((value) => ({
  value,
  label: value,
}));

const testTypeOptions = TEST_TYPES.map((value) => ({
  value,
  label: value,
}));

const sostTypeOptions = REC_SOST_TYPES.map((value) => ({
  value,
  label: value,
}));

const advantagesOptions = REC_ADVANTAGES.map((value) => ({
  value,
  label: value,
}));

const soglsOptions = REC_SOGLS.map((value) => ({
  value,
  label: value,
}));

const PublishRecTabForm: React.FC<Props> = ({ values, onSubmit }) => {
  const isExisting = Boolean(values.id);

  const defaultProfilesOptions = values.profiles.map((value: string) => ({
    value,
    label: value,
  }));

  return (
    <Formik
      initialValues={values}
      onSubmit={onSubmit}
      enableReinitialize={true}
    >
      {({
        values,
        isSubmitting,
        isValid,
        dirty,
        setFieldValue,
        getFieldProps,
      }) => (
        <Form>
          <div className="flex flex-col items-start">
            <div className="flex justify-between w-full">
              <div className="mr-12">
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

                <div className="flex flex-col mb-6">
                  <span className="mb-2">Согласие на зачисление::</span>
                  <InputSelect
                    options={soglsOptions}
                    defaultValue={{
                      value: values.sogl,
                      label: values.sogl,
                    }}
                    onChange={(val) => {
                      setFieldValue('sogl', val);
                    }}
                  />
                </div>

                <div className="flex flex-col mb-6">
                  <span className="mb-2">Состояние:</span>
                  <InputSelect
                    options={sostTypeOptions}
                    defaultValue={{
                      value: values.sostType,
                      label: values.sostType,
                    }}
                    onChange={(val) => {
                      setFieldValue('sostType', val);
                    }}
                  />
                </div>

                <div className="flex flex-col mb-6">
                  <span className="mb-2">Преимущественное право:</span>
                  <InputSelect
                    options={advantagesOptions}
                    defaultValue={{
                      value: values.advantage,
                      label: values.advantage,
                    }}
                    onChange={(val) => {
                      setFieldValue('advantage', val);
                    }}
                  />
                </div>
              </div>

              <div>
                <div className="flex flex-col mb-6">
                  <div className="mb-2">Индивид. достижения:</div>
                  <FormikInputText type="number" name="individ" />
                </div>

                <div className="flex flex-col mb-6">
                  <div className="mb-2">Русский язык:</div>
                  <FormikInputText type="number" name="rusPoint" />
                </div>

                <div className="flex flex-col mb-6">
                  <div className="mb-2">Обществознание:</div>
                  <FormikInputText type="number" name="obshPoint" />
                </div>

                <div className="flex flex-col mb-6">
                  <div className="mb-2">История:</div>
                  <FormikInputText type="number" name="historyPoint" />
                </div>
              </div>
              <div>
                <div className="flex flex-col mb-6">
                  <div className="mb-2">Иностранный язык:</div>
                  <FormikInputText type="number" name="foreignLanguagePoint" />
                </div>

                <div className="flex flex-col mb-6">
                  <div className="mb-2">ГП:</div>
                  <FormikInputText type="number" name="gpPoint" />
                </div>

                <div className="flex flex-col mb-6">
                  <div className="mb-2">ТГП:</div>
                  <FormikInputText type="number" name="tgpPoint" />
                </div>

                <div className="flex flex-col mb-6">
                  <div className="mb-2">УП:</div>
                  <FormikInputText type="number" name="upPoint" />
                </div>
              </div>
              <div>
                <div className="flex flex-col mb-6">
                  <div className="mb-2">Конст. Право РФ:</div>
                  <FormikInputText type="number" name="kpPoint" />
                </div>

                <div className="flex flex-col mb-6">
                  <div className="mb-2">ОКП:</div>
                  <FormikInputText type="number" name="okpPoint" />
                </div>

                <div className="flex flex-col mb-6">
                  <div className="mb-2">Спец. дисциплина (Асп):</div>
                  <FormikInputText type="number" name="specPoint" />
                </div>

                <div className="flex flex-col mb-6">
                  <div className="mb-2"> Сумма баллов: </div>
                  <div className="py-2 px-4 border-b border-sky-700">
                    {calcSummPoints(values)}
                  </div>
                </div>
              </div>
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

export default PublishRecTabForm;
