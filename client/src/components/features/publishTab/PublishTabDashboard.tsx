import { Link } from 'react-router-dom';
import { Column } from 'react-table';

import { useGetPublishTabsQuery } from '../../../app/apiServices/publishTabService';
import { ChoiceProfile } from '../../../app/models/ChoiceProfile';
import { PublishTabView } from '../../../app/models/PublishTab';
import PublishTabTable from './PublishTabTable';

const columns: Array<Column> = [
  {
    Header: 'Id',
    accessor: 'userId',
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
    Header: 'Имя',
    accessor: 'fullName',
  },
  {
    Header: 'Номер',
    accessor: 'individualStr',
    Cell: ({ value, row }) => (
      <>{`${value}-${(row.original as PublishTabView).userId}`}</>
    ),
  },
  {
    Header: 'Испытание',
    accessor: 'testType',
  },
  {
    Header: 'Профили обучения',
    accessor: 'profiles',
    Cell: ({ value }) => (
      <ul>
        {(value as ChoiceProfile[]).map((p) => (
          <li key={p}>{p}</li>
        ))}
      </ul>
    ),
  },
];

const PublishTabDashboard = () => {
  const { data } = useGetPublishTabsQuery();

  if (!data) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <h2 className="mb-6 text-xl text-center">Список подавших документы</h2>
      <PublishTabTable columns={columns} data={data} />
    </div>
  );
};

export default PublishTabDashboard;
