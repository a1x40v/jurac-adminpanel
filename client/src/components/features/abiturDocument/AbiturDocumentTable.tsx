import { useGetDocumentsForUserQuery } from '../../../app/apiServices/documentService';
import { AbiturDocument } from '../../../app/models/AbiturDocument';
import LoadingIndicator from '../../common/LoadingIndicator';
import AbiturDocumentTableRow from './AbiturDocumentTableRow';

interface Props {
  abiturId: number;
}

const AbiturDocumentTable: React.FC<Props> = ({ abiturId }) => {
  const { data, error, isLoading } = useGetDocumentsForUserQuery(abiturId);

  if (isLoading) return <LoadingIndicator label="Загрузка документов..." />;

  if (error) {
    console.log(error);
    return <div>Ошибка загрузки документов</div>;
  }

  if (!data) return <div>Не удалось загрузить документы</div>;

  return (
    <>
      {data.length ? (
        <table>
          <thead>
            <tr className="text-left">
              <th className="px-4 pb-1">Дата</th>
              <th className="px-4 pb-1">Название документа</th>
              <th className="px-4 pb-1">Действия</th>
            </tr>
          </thead>
          <tbody>
            {data.map((doc: AbiturDocument) => (
              <AbiturDocumentTableRow key={doc.id} doc={doc} />
            ))}
          </tbody>
        </table>
      ) : (
        <p>Документы отсутствуют</p>
      )}
    </>
  );
};

export default AbiturDocumentTable;
