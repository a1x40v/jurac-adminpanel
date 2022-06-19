import { Link } from 'react-router-dom';

import {
  useGetAbiturientQuery,
  useUpdateAbiturientMutation,
} from '../../../app/apiServices/abiturientService';
import { AbiturientUpdate } from '../../../app/models/Abiturient';
import { toastError, toastSuccess } from '../../../app/react-toasts';
import LoadingIndicator from '../../common/LoadingIndicator';
import AbiturientForm from './AbiturientForm';

interface Props {
  userId: number;
}

const AbiturientData: React.FC<Props> = ({ userId }) => {
  const [updateAbiturient] = useUpdateAbiturientMutation();

  const { data, isFetching, error } = useGetAbiturientQuery(userId);
  const abitur = data?.user;

  const handleSubmit = async (values: AbiturientUpdate) => {
    try {
      await updateAbiturient(values);
      toastSuccess('Пользователь обновлён');
    } catch (err) {
      console.log(err);
      toastError('Что-то пошло не так');
    }
  };

  if (error) {
    return <div>Не удалось загрузить пользователя с id = {userId}.</div>;
  }

  if (isFetching || !abitur) {
    return <LoadingIndicator />;
  }

  return (
    <div className="min-w-[1200px] font-nanito">
      <Link className="text-sky-700 hover:underline" to={`/abiturients`}>
        Вернуться к списку
      </Link>
      <div className="flex items-center justify-between">
        <h1 className="mt-6 mb-10 text-xl font-bold">
          {abitur.lastName} {abitur.firstName} {abitur.patronymic},{' '}
          {abitur.username}
        </h1>
        <span className="font-bold">Id: {userId}</span>
      </div>
      <div>
        <AbiturientForm abitur={abitur} onSubmit={handleSubmit} />
      </div>
    </div>
  );
};

export default AbiturientData;
