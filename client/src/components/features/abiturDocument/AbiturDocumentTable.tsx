import { useEffect, useState } from 'react';

import {
  openDocumentContent,
  useDeleteDocumentMutation,
  useGetDocumentsForUserQuery,
} from '../../../app/apiServices/documentService';
import { useAppSelector } from '../../../app/hooks/stateHooks';
import { AbiturDocument } from '../../../app/models/AbiturDocument';
import { toastError, toastSuccess } from '../../../app/react-toasts';
import ErrorComponent from '../../common/layout/ErrorComponent';
import LoadingIndicator from '../../common/LoadingIndicator';
import AbiturDocumentTableRow from './AbiturDocumentTableRow';

interface Props {
  abiturId: number;
}

const AbiturDocumentTable: React.FC<Props> = ({ abiturId }) => {
  const { token } = useAppSelector((state) => state.auth);
  const { data, error, isLoading } = useGetDocumentsForUserQuery(abiturId);
  const [deleteDocument] = useDeleteDocumentMutation();
  const [loadingDocs, setLoadingDocs] = useState<number[]>([]);
  const [objectUrls, setObjectUrls] = useState<string[]>([]);

  useEffect(() => {
    return () => {
      objectUrls.forEach((url) => URL.revokeObjectURL(url));
    };
  }, []);

  if (isLoading) return <LoadingIndicator label="Загрузка документов..." />;

  if (error) {
    console.log(error);
    return <ErrorComponent label="Ошибка загрузки документов" />;
  }

  if (!data) return <div>Не удалось загрузить документы</div>;

  const handleDelete = async (docId: number) => {
    if (!loadingDocs.includes(docId)) {
      try {
        setLoadingDocs((docsIds) => [...docsIds, docId]);
        await deleteDocument(docId).unwrap();
        toastSuccess('Документ удалён!');
      } catch (err) {
        toastError('Не удалось удалить документ');
        console.log(err);
      } finally {
        setLoadingDocs((docsIds) => docsIds.filter((x) => x != docId));
      }
    }
  };

  const handleOpen = async (docId: number, fileName: string) => {
    if (token && !loadingDocs.includes(docId)) {
      setLoadingDocs((docsIds) => [...docsIds, docId]);
      const objectUrl = await openDocumentContent(docId, fileName, token);
      setLoadingDocs((docsIds) => docsIds.filter((x) => x != docId));
      setObjectUrls((urls) => [...urls, objectUrl]);
    }
  };

  return (
    <>
      {data.length ? (
        <table className="w-full">
          <thead>
            <tr className="text-left">
              <th className="px-4 pb-1">Id</th>
              <th className="px-4 pb-1">Дата</th>
              <th className="px-4 pb-1">Название документа</th>
              <th className="px-4 pb-1">Действия</th>
            </tr>
          </thead>
          <tbody>
            {data.map((doc: AbiturDocument) => (
              <AbiturDocumentTableRow
                key={doc.id}
                doc={doc}
                isActionsDisabled={loadingDocs.includes(doc.id)}
                onOpen={handleOpen}
                onDelete={handleDelete}
              />
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
