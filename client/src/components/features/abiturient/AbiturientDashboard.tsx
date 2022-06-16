import { Column } from 'react-table';
import dateFormat from 'dateformat';

import { useGetAbiturientsQuery } from '../../../app/apiServices/abiturientService';
import { SEND_STATUS_DESC } from '../../../app/constants/abiturientConstants';
import { useAppSelector } from '../../../app/hooks/stateHooks';
import {
  Abiturient,
  AbtSortableField,
  DocSendStatus,
} from '../../../app/models/Abiturient';
import AbiturientSortableHeader from './AbiturientSortableHeader';
import AbiturientTable from './AbiturientTable';
import AbiturientFilters from './AbiturientFilters';
import { getSortingString } from '../../../utils/apiUtils';
import { Link } from 'react-router-dom';
import LoadingIndicator from '../../common/LoadingIndicator';

const columns: Array<Column> = [
  {
    Header: () => (
      <AbiturientSortableHeader field={AbtSortableField.Id} title="Id" />
    ),
    accessor: 'id',
    Cell: ({ value }) => (
      <Link
        className="text-sky-700 hover:underline"
        to={`/abiturients/${value}`}
      >
        {value}
      </Link>
    ),
  },
  {
    Header: () => (
      <AbiturientSortableHeader
        field={AbtSortableField.Username}
        title="Имя пользователя"
      />
    ),
    accessor: 'username',
    Cell: ({ value, row }) => {
      const username = value as string;
      const abitur = row.original as Abiturient;

      return (
        <Link
          className="text-sky-700 hover:underline"
          to={`/abiturients/${abitur.id}`}
        >
          {username.length > 18 ? `${username.substring(0, 18)}...` : username}
        </Link>
      );
    },
  },
  {
    Header: () => (
      <AbiturientSortableHeader
        field={AbtSortableField.FirstName}
        title="Имя"
        styles={{ minWidth: '120px' }}
      />
    ),
    accessor: 'firstName',
  },
  {
    Header: () => (
      <AbiturientSortableHeader
        field={AbtSortableField.LastName}
        title="Фамилия"
      />
    ),
    accessor: 'lastName',
  },
  {
    Header: () => (
      <AbiturientSortableHeader
        field={AbtSortableField.DateJoined}
        title="Регистрация"
      />
    ),
    accessor: 'dateJoined',
    Cell: (props) => <>{dateFormat(new Date(props.value), 'dd.mm.yy hh:MM')}</>,
  },
  {
    Header: () => (
      <AbiturientSortableHeader
        field={AbtSortableField.Phone}
        title="Телефон"
        styles={{ minWidth: '160px' }}
      />
    ),
    accessor: 'phoneNumber',
  },
  {
    Header: () => (
      <AbiturientSortableHeader
        field={AbtSortableField.Email}
        title="Email"
        styles={{ minWidth: '300px' }}
      />
    ),
    accessor: 'email',
  },
  {
    Header: () => (
      <AbiturientSortableHeader
        field={AbtSortableField.Status}
        title="Статус"
      />
    ),
    accessor: 'sendingStatus',
    Cell: (props) => <>{SEND_STATUS_DESC[props.value as DocSendStatus]}</>,
  },
];

const AbiturientDashboard = () => {
  const { currentPage, pageSize, sorting, filtering } = useAppSelector(
    (state) => state.abiturient
  );

  const orderBy = sorting.length ? getSortingString(sorting) : undefined;

  const { data, isLoading } = useGetAbiturientsQuery({
    pageNumber: currentPage,
    pageSize,
    orderBy,
    filtering,
  });

  if (!data || isLoading) return <LoadingIndicator />;

  return (
    <div>
      <AbiturientFilters />
      <AbiturientTable columns={columns} data={data} />
    </div>
  );
};

export default AbiturientDashboard;
