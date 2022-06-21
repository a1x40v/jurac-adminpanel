import { AiFillCheckCircle, AiFillCloseCircle } from 'react-icons/ai';

import {
  publishProfilesToArray,
  publishProfilesToSet,
  useCreatePublishTabMutation,
  useDeletePublishTabMutation,
  useGetPublishTabQuery,
  useUpdatePublishTabMutation,
} from '../../../app/apiServices/publishTabService';
import { AbiturientTestType } from '../../../app/models/Abiturient';
import {
  PublishTabCreateModel,
  PublishTabUpdateModel,
} from '../../../app/models/PublishTab';
import { toastError, toastSuccess } from '../../../app/react-toasts';
import Button from '../../common/UI/inputs/Button';
import PublishTabForm, { PublishTabFormValues } from './PublishTabForm';

interface Props {
  userId: number;
}

const PublishTabDetail: React.FC<Props> = ({ userId }) => {
  const { data, isLoading, error } = useGetPublishTabQuery(userId);
  const [createPublishTab] = useCreatePublishTabMutation();
  const [updatePublishTab] = useUpdatePublishTabMutation();
  const [deletePublishTab] = useDeletePublishTabMutation();

  if (isLoading) return <div>Загрузка...</div>;

  if (error) return <div>Ошибка соединения</div>;

  if (data === undefined) return <div>Ошибка загрузки</div>;

  let formValues: PublishTabFormValues;

  const isExisting = data !== null;

  if (!isExisting) {
    formValues = {
      userId,
      individualStr: '',
      testType: AbiturientTestType.Ege,
      profiles: [],
    };
  } else {
    const { id, userId, individualStr, testType, fullName, ...other } = data;
    formValues = {
      id,
      userId,
      individualStr,
      testType,
      profiles: publishProfilesToArray(other),
    };
  }

  const handleDelete = async () => {
    try {
      await deletePublishTab(userId);
      toastSuccess('Публикация удалена');
    } catch (err) {
      console.log(err);
      toastError('Что-то пошло не так');
    }
  };

  const statusEl = (
    <div className="flex flex-col items-start my-6">
      <div className="flex items-center">
        {isExisting ? (
          <>
            <AiFillCheckCircle className="mr-2" size={25} color="green" />
            <span className="mr-4">
              Абитуриент уже опубликован в списке подавших документы
            </span>
            <Button label="Удалить публикацию" onClick={handleDelete} />
          </>
        ) : (
          <>
            <AiFillCloseCircle className="mr-2" size={25} color="red" />
            <span>Абитуриент ещё не опубликован в списке подавших</span>
          </>
        )}
      </div>
      {
        <div className="px-20 py-2 mt-4 border-b-2 border-sky-700">
          {isExisting ? 'Обновить публикацию' : 'Создать публикацию'}
        </div>
      }
    </div>
  );

  const handleSubmit = async (values: PublishTabFormValues) => {
    const isExisting = Boolean(values.id);
    const profilesSet = publishProfilesToSet(values.profiles);

    const { individualStr, testType } = values;

    try {
      if (isExisting) {
        const upateModel: PublishTabUpdateModel = {
          userId,
          individualStr,
          testType,
          ...profilesSet,
        };
        await updatePublishTab(upateModel);
        toastSuccess('Публикация обновлена');
      } else {
        const createModel: PublishTabCreateModel = {
          userId,
          individualStr,
          testType,
          ...profilesSet,
        };
        await createPublishTab(createModel);
        toastSuccess('Публикация создана');
      }
    } catch (err) {
      console.log(err);
      toastError('Что-то пошло не так');
    }
  };

  return (
    <div>
      {statusEl}
      <PublishTabForm values={formValues} onSubmit={handleSubmit} />
    </div>
  );
};

export default PublishTabDetail;
