import { Link } from 'react-router-dom';
import { Column } from 'react-table';

import { useGetPublishTabsQuery } from '../../../app/apiServices/publishTabService';
import { ChoiceProfile } from '../../../app/models/ChoiceProfile';
import { PublishTabView } from '../../../app/models/PublishTab';
import LoadingIndicator from '../../common/LoadingIndicator';
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
  const { data, isLoading } = useGetPublishTabsQuery();

  if (!data || isLoading)
    return (
      <div className="w-full">
        <LoadingIndicator />
      </div>
    );

  if (data.length === 0)
    return (
      <div className="w-full text-center pt-14 text-lg">
        Подавшие документы отсутствуют
      </div>
    );

  return (
    <div className="flex justify-center w-full py-6 pr-6 pl-9">
      <div>
        <h2 className="mb-6 text-xl text-center">Список подавших документы</h2>
        <PublishTabTable columns={columns} data={data} />
      </div>
    </div>
  );
};

export default PublishTabDashboard;
