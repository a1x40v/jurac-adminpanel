import dateFormat from 'dateformat';

import { AbiturDocument } from '../../../app/models/AbiturDocument';

interface Props {
  doc: AbiturDocument;
}

const AbiturDocumentTableRow: React.FC<Props> = ({ doc }) => {
  return (
    <tr>
      <td className="px-4 py-1">
        {dateFormat(new Date(doc.datePub), 'dd.mm.yy HH:MM')}
      </td>
      <td className="px-4 py-1">{doc.doc}</td>
      <td className="px-4 py-1">actions</td>
    </tr>
  );
};

export default AbiturDocumentTableRow;
