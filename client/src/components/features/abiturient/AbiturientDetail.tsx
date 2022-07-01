import { Link } from 'react-router-dom';
import { useParams } from 'react-router-dom';

import { useGetAbiturientQuery } from '../../../app/apiServices/abiturientService';
import Tabs from '../../common/layout/tabs/Tabs';
import LoadingIndicator from '../../common/LoadingIndicator';
import PublishRecTabDetail from '../publishRecTab/PublishRecTabDetail';
import PublishTabDetail from '../publishTab/PublishTabDetail';
import AbiturientData from './AbiturientData';
import AbiturientEmail from './AbiturientEmail';

const AbiturientDetail = () => {
  let { id } = useParams();
  const userId = Number(id);

  const { data, isFetching, error } = useGetAbiturientQuery(userId);
  const abitur = data?.user;

  if (error) {
    return <div>Не удалось загрузить пользователя с id = {userId}.</div>;
  }

  if (isFetching || !abitur) {
    return (
      <div className="w-full">
        <LoadingIndicator />
      </div>
    );
  }

  const tabsData = [
    {
      navTitle: 'Данные',
      content: <AbiturientData abitur={abitur} />,
    },
    {
      navTitle: 'Публиковать в списке подавших',
      content: (
        <PublishTabDetail userId={userId} isSnils={Boolean(abitur.snils)} />
      ),
    },
    {
      navTitle: 'Публиковать в списке рекомендованных',
      content: (
        <PublishRecTabDetail userId={userId} isSnils={Boolean(abitur.snils)} />
      ),
    },
    {
      navTitle: 'Написать на почту',
      content: <AbiturientEmail userId={userId} userEmail={abitur.email} />,
    },
  ];

  return (
    <div className="min-w-[1200px] ml-[200px] py-6 font-nanito">
      <Link className="text-sky-700 hover:underline" to={`/abiturients`}>
        Вернуться к списку
      </Link>
      <div className="flex items-center justify-between">
        <h1 className="mt-6 mb-6 text-xl font-bold">
          {abitur.lastName} {abitur.firstName} {abitur.patronymic},{' '}
          {abitur.username}
        </h1>
        <span className="font-bold">Id: {userId}</span>
      </div>
      <Tabs data={tabsData} />
    </div>
  );
};

export default AbiturientDetail;
