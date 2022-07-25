import MiddleLineLabel from '../../common/UI/labels/MiddleLineLabel';
import DocumentUploadWidget from '../documentUpload/DocumentUploadWidget';
import AbiturDocumentTable from './AbiturDocumentTable';

interface Props {
  abiturId: number;
}

const AbiturDocumentDashboard: React.FC<Props> = ({ abiturId }) => {
  return (
    <div>
      <MiddleLineLabel>
        <span className="text-lg">Документы пользователя</span>
      </MiddleLineLabel>
      <div className="mt-4">
        <AbiturDocumentTable abiturId={abiturId} />
      </div>
      <div className="mt-10">
        <h3 className="mb-4 text-center">Загрузить новый файл</h3>
        <DocumentUploadWidget abiturId={abiturId} />
      </div>
    </div>
  );
};

export default AbiturDocumentDashboard;
