import { Column, usePagination, useTable } from 'react-table';
import dateFormat from 'dateformat';

import ReactTable from '../../common/reactTable/ReactTable';
import { EmailMessage } from '../../../app/models/EmailMessage';
import { Link } from 'react-router-dom';
import PaginationBar from '../../common/reactTable/PaginationBar';

interface Props {
  messages: EmailMessage[];
}

const columns: Array<Column> = [
  {
    Header: 'Id',
    accessor: 'id',
    Cell: ({ value }) => (
      <Link
        className="text-sky-700 hover:underline"
        to={`/emailmessages/${value}`}
      >
        {value}
      </Link>
    ),
  },
  { Header: 'Отправитель', accessor: 'senderUsername' },
  {
    Header: 'Дата',
    accessor: 'sentAt',
    Cell: (props) => <>{dateFormat(new Date(props.value), 'dd.mm.yy HH:MM')}</>,
  },
  { Header: 'Адрес', accessor: 'recipientEmail' },
  { Header: 'Тема', accessor: 'subject' },
  { Header: 'Содержимое', accessor: 'contentText' },
];

const EmailMessagesTable: React.FC<Props> = ({ messages }) => {
  const tableInstance = useTable(
    {
      columns,
      data: messages,
      initialState: { pageIndex: 0, pageSize: 5 },
    },
    usePagination
  );

  return (
    <div className="my-12">
      {messages.length ? (
        <div>
          <ReactTable tableInstance={tableInstance} />
          <PaginationBar
            tableInstance={tableInstance}
            pageSizes={[5, 10, 15, 25]}
          />
        </div>
      ) : (
        <div className="text-lg text-center">
          Отправленные абитуриенту письма отсутствуют
        </div>
      )}
    </div>
  );
};

export default EmailMessagesTable;
