import { Link } from 'react-router-dom';
import { Column } from 'react-table';
import ScaleLoader from 'react-spinners/ScaleLoader';

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
  const [deployRecTabs, { isLoading: isDeploying }] =
    useDeployPublishRecTabsMutation();

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

  const handleDeploy = async () => {
    try {
      await deployRecTabs().unwrap();
      toastSuccess('Файлы размещены на сайте');
    } catch (err) {
      console.log(err);
      toastError('Что-то пошло не так');
    }
  };

  return (
    <div className="flex justify-center w-full py-6 pr-6 pl-9">
      <div>
        <h2 className="mb-6 text-xl text-center">
          Список рекомендованных к зачислению
        </h2>
        <div className="flex items-center py-4">
          <span className="mr-4">
            Разместить файлы с рекомендованными к зачислению на сайт
          </span>
          <Button
            label="Разместить"
            disabled={isDeploying}
            onClick={handleDeploy}
          />
          {isDeploying ? (
            <div className="ml-4">
              <ScaleLoader color="rgb(12,74,110)" />
            </div>
          ) : null}
        </div>
        <PublishRecTabTable columns={columns} data={data} />
      </div>
    </div>
  );
};

export default PublishRecTabDashboard;
