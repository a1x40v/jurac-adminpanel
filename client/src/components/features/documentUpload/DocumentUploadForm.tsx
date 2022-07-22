import { Form, Formik } from 'formik';

import { useCreateDocumentMutation } from '../../../app/apiServices/documentService';
import { DOC_TYPES } from '../../../app/constants/documentConstants';
import noPhoto from '../../../assets/images/no-photo.svg';
import FormikInputText from '../../common/UI/formik/FormikInputText';
import Button from '../../common/UI/inputs/Button';
import InputSelect, { SelectOption } from '../../common/UI/inputs/InputSelect';
import { UploadedDocument } from './DocumentUploadWidget';

interface Props {
  userId: number;
  doc: UploadedDocument;
}

interface FormValues {
  customName: string;
  docType: string;
}

const documentTypeOptions: SelectOption<string>[] = DOC_TYPES.map((value) => ({
  value,
  label: value === '' ? 'Не указано' : value,
}));

const DocumentUploadForm: React.FC<Props> = ({ userId, doc }) => {
  const [createDocument] = useCreateDocumentMutation();
  const inititalValues: FormValues = {
    customName: doc.customName,
    docType: doc.docType,
  };
  const previewSrc = doc.preview || noPhoto;

  const handleSubmit = async (vals: FormValues) => {
    const docType = vals.docType.replace(/\s/g, '_').replace(/[()]/g, '');
    const customName = vals.customName.replace(/\s/g, '_');
    const file = new File([doc.file], `${docType}${customName}.${doc.ext}`, {
      type: doc.file.type,
    });
    console.log('file', file);

    try {
      await createDocument({ file, userId }).unwrap();
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <Formik
      initialValues={inititalValues}
      enableReinitialize={true}
      onSubmit={handleSubmit}
    >
      {({ values, setFieldValue }) => (
        <Form>
          <div className="mr-10 flex">
            <div className="border-2 border-sky-700 p-3">
              <img className="max-w-[250px] max-h-[250px]" src={previewSrc} />
            </div>
            <div className="flex grow mx-8 my-2">
              <div className="mr-6">
                <p className="mb-2 text-center">Тип документа</p>
                <InputSelect
                  options={documentTypeOptions}
                  defaultValue={{ value: '', label: 'Не указано' }}
                  onChange={(val) => setFieldValue('docType', val)}
                />
              </div>
              <div className="grow">
                <p className="mb-2 text-center">Название:</p>
                <FormikInputText name="customName" isFullWidth={true} />
              </div>
            </div>
            <div>
              <Button type="submit" label="Send" />
            </div>
          </div>
          <div>
            <pre>{JSON.stringify(values, null, 2)}</pre>
          </div>
        </Form>
      )}
    </Formik>
  );
};

export default DocumentUploadForm;
