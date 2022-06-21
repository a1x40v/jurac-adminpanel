import { Link } from 'react-router-dom';
import { Column } from 'react-table';
import { useGetPublishRecTabsQuery } from '../../../app/apiServices/publishRecTabService';
import { ChoiceProfile } from '../../../app/models/ChoiceProfile';
import LoadingIndicator from '../../common/LoadingIndicator';
import PublishRecTabTable from './PublishRecTabTable';

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
    Header: 'Испытание',
    accessor: 'testType',
  },
  {
    Header: 'Сумма баллов',
    accessor: 'sumPoints',
  },
  {
    Header: 'Состояние',
    accessor: 'sostType',
  },
  {
    Header: 'Согласие',
    accessor: 'sogl',
  },
  {
    Header: 'Приемущ. право',
    accessor: 'advantage',
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

const PublishRecTabDashboard = () => {
  const { data, isLoading } = useGetPublishRecTabsQuery();

  if (!data || isLoading)
    return (
      <div className="w-full">
        <LoadingIndicator />
      </div>
    );

  if (data.length === 0)
    return (
      <div className="w-full text-center pt-14 text-lg">
        Рекомендованные к зачислению отсутствуют
      </div>
    );

  return (
    <div className="flex justify-center w-full py-6 pr-6 pl-9">
      <div>
        <h2 className="mb-6 text-xl text-center">
          Список рекомендованных к зачислению
        </h2>
        <PublishRecTabTable columns={columns} data={data} />
      </div>
    </div>
  );
};

export default PublishRecTabDashboard;
