import { Link, useParams } from 'react-router-dom';

import {
  abiturientApi,
  transformToUpdate,
  useGetAbiturientQuery,
  useUpdateAbiturientMutation,
} from '../../../app/apiServices/abiturientService';
import { AbiturientUpdate } from '../../../app/models/Abiturient';
import LoadingIndicator from '../../common/LoadingIndicator';
import AbiturientForm from './AbiturientForm';

const AbiturientDetail = () => {
  let { id } = useParams();

  const [updateAbiturient] = useUpdateAbiturientMutation();

  const { data, isFetching, error } = useGetAbiturientQuery(Number(id));
  const abitur = data?.user;

  const handleSubmit = async (values: AbiturientUpdate) => {
    await updateAbiturient(values);
  };

  if (error) {
    return <div>Не удалось загрузить пользователя с id = {id}.</div>;
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
        <span className="font-bold">Id: {id}</span>
      </div>
      <div>
        <AbiturientForm
          abitur={transformToUpdate(abitur)}
          onSubmit={handleSubmit}
        />
      </div>
    </div>
  );
};

export default AbiturientDetail;
