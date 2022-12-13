import { Form, Formik, FormikHelpers } from 'formik';
import * as Yup from 'yup';

import { DOC_TYPES } from '../../../app/constants/documentConstants';
import { UploadedDocument } from '../../../app/models/AbiturDocument';
import FormikInputText from '../../common/UI/formik/FormikInputText';
import Button from '../../common/UI/inputs/Button';
import InputSelect, { SelectOption } from '../../common/UI/inputs/InputSelect';
import AttachedFileMenu from './AttachedFileMenu';
import DocumentUploadWidgetDropzone from './DocumentUploadWidgetDropzone';

interface Props {
  buttonTitle?: string;
  isFileRequired?: boolean;
  onSubmit: (doc: UploadedDocument) => void;
}

interface FormValues {
  customName: string;
  docType: string;
  file?: File;
}

const validationSchema = Yup.object({
  docType: Yup.string().required('Обязательное поле'),
  customName: Yup.string()
    .required('Обязательное поле')
    .max(50, 'Должно быть не более 50 символов'),
});

const documentTypeOptions: SelectOption<string>[] = DOC_TYPES.map((value) => ({
  value,
  label: value === '' ? 'Не указано' : value,
}));

const DocumentUploadForm: React.FC<Props> = ({
  isFileRequired = true,
  buttonTitle = 'Загрузить',
  onSubmit,
}) => {
  const inititalValues: FormValues = {
    customName: '',
    docType: '',
  };

  if (isFileRequired) {
    validationSchema.concat(
      Yup.object().shape({
        file: Yup.mixed().required('File is required'),
      })
    );
  }

  const handleSubmit = async (
    vals: FormValues,
    formikHelpers: FormikHelpers<FormValues>
  ) => {
    const docType = vals.docType.replace(/\s/g, '_').replace(/[()]/g, '');
    const customName = vals.customName.trim().replace(/\s/g, '_');

    await onSubmit({
      customName,
      docType,
      file: vals.file,
    });

    formikHelpers.setSubmitting(false);
    formikHelpers.resetForm();
  };

  return (
    <>
      <Formik
        initialValues={inititalValues}
        enableReinitialize={true}
        validationSchema={validationSchema}
        onSubmit={handleSubmit}
      >
        {({ values, isSubmitting, isValid, dirty, setFieldValue }) => (
          <Form>
            <div className="flex flex-col">
              <div className="grow">
                <div className="flex items-center mx-8 my-2 grow">
                  <div className="mr-6">
                    <p className="mb-2 text-center">Тип документа</p>
                    <InputSelect
                      options={documentTypeOptions}
                      defaultValue={{ value: '', label: 'Не указано' }}
                      onChange={(val) => setFieldValue('docType', val)}
                      menuPlacement="top"
                    />
                  </div>
                  <div className="grow mr-6">
                    <p className="mb-2 text-center">Название:</p>
                    <FormikInputText name="customName" isFullWidth={true} />
                  </div>
                  <div className="self-end">
                    <Button
                      type="submit"
                      label={isSubmitting ? 'Загрузка...' : buttonTitle}
                      disabled={isSubmitting || !isValid || !dirty}
                    />
                  </div>
                </div>
              </div>
            </div>

            {values.file ? (
              <div className="mt-4">
                {values.file ? (
                  <AttachedFileMenu
                    file={values.file}
                    onCancel={() => setFieldValue('file', undefined)}
                  />
                ) : null}
              </div>
            ) : (
              <div className="mt-4 mx-8">
                <DocumentUploadWidgetDropzone
                  onDropFile={(file: File) => {
                    setFieldValue('file', file);
                    if (!values.customName) {
                      const dotSplit = file.name.split('.');
                      dotSplit.pop();
                      setFieldValue('customName', dotSplit.join('.'));
                    }
                  }}
                />
              </div>
            )}
          </Form>
        )}
      </Formik>
    </>
  );
};

export default DocumentUploadForm;
