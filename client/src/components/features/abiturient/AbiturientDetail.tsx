import { Link, useParams } from 'react-router-dom';

import { abiturientApi } from '../../../app/apiServices/abiturientService';
import { useAppSelector } from '../../../app/hooks/stateHooks';
import { getSortingString } from '../../../utils/apiUtils';
import LoadingIndicator from '../../common/LoadingIndicator';
import AbiturientForm from './AbiturientForm';

const AbiturientDetail = () => {
  let { id } = useParams();
  const { currentPage, pageSize, sorting, filtering } = useAppSelector(
    (state) => state.abiturient
  );
  const orderBy = sorting.length ? getSortingString(sorting) : undefined;

  const { abitur, isFetching } = abiturientApi.useGetAbiturientsQuery(
    { pageNumber: currentPage, pageSize, orderBy, filtering },
    {
      selectFromResult: ({ data, isFetching }) => ({
        abitur: data?.users.find((abitur) => abitur.id === Number(id)),
        isFetching,
      }),
    }
  );

  if (!isFetching && !abitur) {
    return <div>Пользователь с id = {id} не найден.</div>;
  }

  if (isFetching || !abitur) {
    return <LoadingIndicator />;
  }

  return (
    <div className="min-w-[1200px] font-nanito">
      <Link className="text-sky-700 hover:underline" to={`/abiturients`}>
        Вернуться к списку
      </Link>
      <h1 className="mt-6 mb-10 text-xl font-bold">
        {abitur.lastName} {abitur.firstName} {abitur.patronymic}. Id: {id}
      </h1>
      <div>
        <AbiturientForm abitur={abitur} />
      </div>
    </div>
  );
};

export default AbiturientDetail;
