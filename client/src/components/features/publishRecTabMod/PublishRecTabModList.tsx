import dateFormat from 'dateformat';
import { Link } from 'react-router-dom';
import { ScaleLoader } from 'react-spinners';
import { Column } from 'react-table';

import { useGetPublishRecTabModsQuery } from '../../../app/apiServices/publishRecTabModService';
import { useDeployPublishRecTabsMutation } from '../../../app/apiServices/publishRecTabService';
import { PUBLISH_REC_MOD_DESC } from '../../../app/constants/publishRecTabModConstants';
import { PublishRecTabModType } from '../../../app/models/PublishRecTabMod';
import { toastError, toastSuccess } from '../../../app/react-toasts';
import LoadingIndicator from '../../common/LoadingIndicator';
import Button from '../../common/UI/inputs/Button';
import PublishRecTabModTable from './PublishRecTabModTable';

const REC_MOD_COLORS: { [key in PublishRecTabModType]: React.CSSProperties } = {
  [PublishRecTabModType.Created]: { backgroundColor: '#5cdb65' },
  [PublishRecTabModType.Updated]: { backgroundColor: '#f7b931' },
  [PublishRecTabModType.Hidden]: { backgroundColor: '#f5e94c' },
  [PublishRecTabModType.Showed]: { backgroundColor: '#83a2f7' },
  [PublishRecTabModType.Deleted]: { backgroundColor: '#f26363' },
};

const columns: Array<Column> = [
  {
    Header: 'Id студента',
    accessor: 'abiturientId',
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
    Header: 'Имя студента',
    accessor: 'studentName',
  },
  {
    Header: 'Время изменения',
    accessor: 'createdAt',
    Cell: ({ value }) => <>{dateFormat(new Date(value), 'dd.mm.yy HH:MM')}</>,
  },
  {
    Header: 'Тип',
    accessor: 'type',
    Cell: ({ value }) => {
      const modType = value as PublishRecTabModType;
      return (
        <div
          className="inline-block py-1 px-4 rounded-xl"
          style={REC_MOD_COLORS[modType]}
        >
          {PUBLISH_REC_MOD_DESC[modType]}
        </div>
      );
    },
  },
  {
    Header: 'Автор',
    accessor: 'author',
  },
];

const PublishRecTabModList = () => {
  const { data, isLoading } = useGetPublishRecTabModsQuery();
  const [deployRecTabs, { isLoading: isDeploying }] =
    useDeployPublishRecTabsMutation();

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
        disabled={isDeploying || data?.length === 0}
        onClick={handleDeploy}
      />
      {isDeploying ? (
        <div className="ml-4">
          <ScaleLoader color="rgb(12,74,110)" />
        </div>
      ) : null}
    </div>
  );

  if (!data || isLoading)
    return (
      <div className="w-full">
        <LoadingIndicator />
      </div>
    );

  return (
    <div>
      {deployEl}
      <PublishRecTabModTable data={data} columns={columns} />
    </div>
  );
};

export default PublishRecTabModList;
