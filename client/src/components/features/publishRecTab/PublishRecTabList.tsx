import { Link } from 'react-router-dom';
import { Column } from 'react-table';
import {
  BsFillFileEarmarkCheckFill,
  BsFillFileEarmarkExcelFill,
} from 'react-icons/bs';

import { ChoiceProfile } from '../../../app/models/ChoiceProfile';
import { useGetPublishRecTabsQuery } from '../../../app/apiServices/publishRecTabService';
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
    Header: 'Выложить',
    accessor: 'isPublished',
    Cell: ({ value }) => (
      <>
        {value ? (
          <BsFillFileEarmarkCheckFill size={25} color="green" />
        ) : (
          <BsFillFileEarmarkExcelFill size={25} color="red" />
        )}
      </>
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
  {
    Header: 'Комментарий',
    accessor: 'comment',
  },
];

const PublishRecTabList = () => {
  const { data, isLoading } = useGetPublishRecTabsQuery();

  if (!data || isLoading)
    return (
      <div className="w-full">
        <LoadingIndicator />
      </div>
    );

  return (
    <div>
      {data.length === 0 ? (
        <div className="w-full text-lg text-center pt-14">
          Рекомендованные к зачислению отсутствуют
        </div>
      ) : (
        <PublishRecTabTable columns={columns} data={data} />
      )}
    </div>
  );
};

export default PublishRecTabList;
