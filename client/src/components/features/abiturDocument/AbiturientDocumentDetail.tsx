import { Link, useParams } from 'react-router-dom';
import dateFormat from 'dateformat';

import {
  useGetDocumentQuery,
  useUpdateDocumentMutation,
} from '../../../app/apiServices/documentService';
import { toastError, toastSuccess } from '../../../app/react-toasts';
import { createDocumentFilename } from '../../../utils/features/documentUtils';
import LoadingIndicator from '../../common/LoadingIndicator';
import DocumentUploadForm from '../documentUpload/DocumentUploadForm';
import MiddleLineLabel from '../../common/UI/labels/MiddleLineLabel';
import { UploadedDocument } from '../../../app/models/AbiturDocument';
import ErrorComponent from '../../common/layout/ErrorComponent';

const AbiturientDocumentDetail: React.FC = () => {
  const { id } = useParams();
  const docId = Number(id);
  const { data, error, isLoading: isFetching } = useGetDocumentQuery(docId);
  const [updateDocument] = useUpdateDocumentMutation();

  if (error) {
    return (
      <ErrorComponent
        label={`Не удалось загрузить документ с id = ${docId}.`}
      />
    );
  }

  if (isFetching || !data) {
    return (
      <div className="w-full">
        <LoadingIndicator />
      </div>
    );
  }

  const handleSubmit = async (doc: UploadedDocument) => {
    try {
      const fileName = createDocumentFilename(
        doc.file ? doc.file.name : data.doc,
        doc.docType,
        doc.customName
      );
      await updateDocument({
        id: docId,
        file: doc.file,
        fileName,
        docType: doc.docType,
      }).unwrap();
      toastSuccess('Документ обновлён');
    } catch (err) {
      toastError('Ошибка обновления документа');
      console.log(err);
    }
  };

  return (
    <div className="min-w-[1200px] ml-[200px] py-6 font-nanito">
      <Link
        className="text-sky-700 hover:underline"
        to={`/abiturients/${data.userId}`}
      >
        Вернуться к абитуриенту
      </Link>
      <div className="flex items-center justify-between">
        <h1 className="mt-6 mb-6 text-xl font-bold">{data.doc}</h1>
        <span className="font-bold">Id: {data.id}</span>
      </div>
      <div className="mb-6">
        <p>Тип: {data.nameDoc}</p>
        <p>Размещён: {dateFormat(new Date(data.datePub), 'dd.mm.yy HH:MM')}</p>
      </div>
      <MiddleLineLabel>
        <span className="text-lg">Переименовать или заменить документ</span>
      </MiddleLineLabel>
      <div className="mt-6">
        <DocumentUploadForm
          buttonTitle="Обновить документ"
          isFileRequired={false}
          onSubmit={handleSubmit}
        />
      </div>
    </div>
  );
};

export default AbiturientDocumentDetail;
