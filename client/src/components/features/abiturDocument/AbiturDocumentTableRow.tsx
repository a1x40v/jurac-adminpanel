import dateFormat from 'dateformat';
import { Link } from 'react-router-dom';

import { AbiturDocument } from '../../../app/models/AbiturDocument';
import Button, { ButtonType } from '../../common/UI/inputs/Button';
import ConfirmationButton from '../../common/UI/inputs/ConfirmationButton';

interface Props {
  doc: AbiturDocument;
  isActionsDisabled?: boolean;
  onDelete: (docId: number) => void;
  onOpen: (docId: number, fileName: string) => void;
}

const AbiturDocumentTableRow: React.FC<Props> = ({
  doc,
  isActionsDisabled: isActionDisabled = false,
  onDelete,
  onOpen,
}) => {
  return (
    <tr className="hover:bg-blue-100">
      <td className="px-4 py-1">
        <Link
          className="text-sky-700 hover:underline"
          to={`/documents/${doc.id}`}
        >
          {doc.id}
        </Link>
      </td>
      <td className="px-4 py-1">
        {dateFormat(new Date(doc.datePub), 'dd.mm.yy HH:MM')}
      </td>
      <td className="px-4 py-1">{doc.doc}</td>
      <td className="px-4 py-1">
        <div className="flex justify-between">
          <Button
            label="Посмотреть"
            disabled={isActionDisabled}
            onClick={() => onOpen(doc.id, doc.doc)}
          />
          <ConfirmationButton
            label="Удалить"
            confirmationLabel="Уверены?"
            disabled={isActionDisabled}
            buttonType={ButtonType.warning}
            onClick={() => onDelete(doc.id)}
          />
        </div>
      </td>
    </tr>
  );
};

export default AbiturDocumentTableRow;
