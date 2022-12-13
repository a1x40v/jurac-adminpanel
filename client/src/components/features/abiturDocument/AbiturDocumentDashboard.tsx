import { useCreateDocumentMutation } from '../../../app/apiServices/documentService';
import { UploadedDocument } from '../../../app/models/AbiturDocument';
import { toastError, toastSuccess } from '../../../app/react-toasts';
import { createDocumentFilename } from '../../../utils/features/documentUtils';
import MiddleLineLabel from '../../common/UI/labels/MiddleLineLabel';
import DocumentUploadForm from '../documentUpload/DocumentUploadForm';
import AbiturDocumentTable from './AbiturDocumentTable';

interface Props {
  abiturId: number;
}

const AbiturDocumentDashboard: React.FC<Props> = ({ abiturId }) => {
  const [createDocument] = useCreateDocumentMutation();

  const handleSubmit = async (doc: UploadedDocument) => {
    if (doc.file) {
      try {
        const fileName = createDocumentFilename(
          doc.file.name,
          doc.docType,
          doc.customName
        );
        await createDocument({
          userId: abiturId,
          fileName,
          file: doc.file,
          docType: doc.docType,
        }).unwrap();
        toastSuccess('Документ создан');
      } catch (err) {
        toastError('Ошибка создания документа');
        console.log(err);
      }
    } else {
      console.log(`Dont't have a file`);
    }
  };

  return (
    <div>
      <MiddleLineLabel>
        <span className="text-lg">Документы пользователя</span>
      </MiddleLineLabel>
      <div className="mt-4">
        <AbiturDocumentTable abiturId={abiturId} />
      </div>
      <div className="mt-10">
        <MiddleLineLabel>
          <span className="text-lg">Загрузить новый документ</span>
        </MiddleLineLabel>
        <div className="mt-6">
          <DocumentUploadForm onSubmit={handleSubmit} />
        </div>
      </div>
    </div>
  );
};

export default AbiturDocumentDashboard;
