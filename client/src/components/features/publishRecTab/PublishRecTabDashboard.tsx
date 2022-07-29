import { Link } from 'react-router-dom';
import { Column } from 'react-table';
import ScaleLoader from 'react-spinners/ScaleLoader';
import { BsFillFileEarmarkCheckFill, BsFillFileEarmarkExcelFill } from 'react-icons/bs';

import {
  useDeployPublishRecTabsMutation,
  useGetPublishRecTabsQuery,
} from '../../../app/apiServices/publishRecTabService';
import { ChoiceProfile } from '../../../app/models/ChoiceProfile';
import LoadingIndicator from '../../common/LoadingIndicator';
import Button from '../../common/UI/inputs/Button';
import PublishRecTabTable from './PublishRecTabTable';
import { toastError, toastSuccess } from '../../../app/react-toasts';

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
    Cell: ({ value }) => <>{value ? <BsFillFileEarmarkCheckFill size={25} color="green" /> : <BsFillFileEarmarkExcelFill size={25} color="red" />}</>,
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

const PublishRecTabDashboard = () => {
  const { data, isLoading } = useGetPublishRecTabsQuery();
  const [deployRecTabs, { isLoading: isDeploying }] =
    useDeployPublishRecTabsMutation();

  if (!data || isLoading)
    return (
      <div className="w-full">
        <LoadingIndicator />
      </div>
    );

  const handleDeploy = async () => {
    try {
      await deployRecTabs().unwrap();
      toastSuccess('Файлы размещены на сайте');
    } catch (err) {
      console.log(err);
      toastError('Что-то пошло не так');
    }
  };

  const deployEl = (
    <div className="flex items-center py-4">
      <span className="mr-4">
        Разместить файлы с рекомендованными к зачислению на сайт
      </span>
      <Button
        label={isDeploying ? 'Загрузка...' : 'Разместить'}
        disabled={isDeploying}
        onClick={handleDeploy}
      />
      {isDeploying ? (
        <div className="ml-4">
          <ScaleLoader color="rgb(12,74,110)" />
        </div>
      ) : null}
    </div>
  );

  return (
    <div className="flex justify-center w-full py-6 pr-6 pl-9">
      <div className="w-full">
        <h2 className="mb-6 text-xl text-center">
          Список рекомендованных к зачислению
        </h2>
        {deployEl}
        {data.length === 0 ? (
          <div className="w-full text-lg text-center pt-14">
            Рекомендованные к зачислению отсутствуют
          </div>
        ) : (
          <PublishRecTabTable columns={columns} data={data} />
        )}
      </div>
    </div>
  );
};

export default PublishRecTabDashboard;
