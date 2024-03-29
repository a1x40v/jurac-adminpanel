import { AiFillCheckCircle, AiFillCloseCircle } from 'react-icons/ai';
import {
  useCreatePublishRecTabMutation,
  useDeletePublishRecTabMutation,
  useGetPublishRecTabQuery,
  useUpdatePublishRecTabMutation,
} from '../../../app/apiServices/publishRecTabService';
import {
  publishProfilesToArray,
  publishProfilesToSet,
} from '../../../app/apiServices/publishTabService';
import { AbiturientTestType } from '../../../app/models/Abiturient';
import {
  PublishRecAdvantage,
  PublishRecSogl,
  PublishRecSostType,
  PublishRecTabCreateModel,
  PublishRecTabUpdateModel,
} from '../../../app/models/PublishRecTab';
import { toastError, toastSuccess } from '../../../app/react-toasts';
import Button from '../../common/UI/inputs/Button';
import PublishRecTabForm, {
  PublishRecTabFormValues,
} from './PublishRecTabForm';

interface Props {
  userId: number;
  isSnils: boolean;
}

const PublishRecTabDetail: React.FC<Props> = ({ userId, isSnils }) => {
  const { data, isLoading, error } = useGetPublishRecTabQuery(userId);
  const [createPublishRecTab] = useCreatePublishRecTabMutation();
  const [updatePublishRecTab] = useUpdatePublishRecTabMutation();
  const [deletePublishRecTab, { isLoading: isDeleting }] =
    useDeletePublishRecTabMutation();

  if (isLoading) return <div>Загрузка...</div>;

  if (error) return <div>Ошибка соединения</div>;

  if (data === undefined) return <div>Ошибка загрузки</div>;

  let formValues: PublishRecTabFormValues;

  const isExisting = data !== null;

  if (!isExisting) {
    formValues = {
      userId,
      testType: AbiturientTestType.Ege,
      sogl: PublishRecSogl.NotSent,
      sostType: PublishRecSostType.NotRec,
      advantage: PublishRecAdvantage.HasNot,
      individ: 0,
      rusPoint: 0,
      obshPoint: 0,
      kpPoint: 0,
      specPoint: 0,
      foreignLanguagePoint: 0,
      gpPoint: 0,
      historyPoint: 0,
      okpPoint: 0,
      tgpPoint: 0,
      upPoint: 0,
      profiles: [],
      isPublished: false,
      comment: '',
    };
  } else {
    const {
      fullName,
      id,
      userId,
      testType,
      sogl,
      sostType,
      advantage,
      individ,
      rusPoint,
      obshPoint,
      kpPoint,
      specPoint,
      foreignLanguagePoint,
      gpPoint,
      historyPoint,
      okpPoint,
      tgpPoint,
      upPoint,
      isPublished,
      comment,
      ...other
    } = data;
    formValues = {
      id,
      userId,
      testType,
      sogl,
      sostType,
      advantage,
      individ,
      rusPoint,
      obshPoint,
      kpPoint,
      specPoint,
      foreignLanguagePoint,
      gpPoint,
      historyPoint,
      okpPoint,
      tgpPoint,
      upPoint,
      isPublished,
      comment,
      profiles: publishProfilesToArray(other),
    };
  }

  const handleDelete = async () => {
    try {
      await deletePublishRecTab(userId).unwrap();
      toastSuccess('Публикация удалена');
    } catch (err) {
      console.log(err);
      toastError('Что-то пошло не так');
    }
  };

  const statusEl = (
    <div className="flex flex-col items-start my-6">
      {isSnils ? null : (
        <div className="mb-4 py-4 px-6 bg-red-200 border border-red-700 rounded-md">
          Для пользователя не указан СНИЛС
        </div>
      )}
      <div className="flex items-center">
        {isExisting ? (
          <>
            <AiFillCheckCircle className="mr-2" size={25} color="green" />
            <span className="mr-4">
              Абитуриент опубликован в списке рекомендованных
            </span>
            <Button
              label={isDeleting ? 'Загрузка...' : 'Удалить публикацию'}
              disabled={isDeleting}
              onClick={handleDelete}
            />
          </>
        ) : (
          <>
            <AiFillCloseCircle className="mr-2" size={25} color="red" />
            <span>Абитуриент ещё не опубликован в списке рекомендованных</span>
          </>
        )}
      </div>
      {
        <div className="w-full py-2 mt-4 text-center border-b-2 border-sky-700">
          {isExisting ? 'Обновить публикацию' : 'Создать публикацию'}
        </div>
      }
    </div>
  );

  const handleSubmit = async (values: PublishRecTabFormValues) => {
    const isExisting = Boolean(values.id);
    const { id, profiles, sogl, advantage, sostType, ...other } = values;
    const profilesSet = publishProfilesToSet(values.profiles);

    const newVals = {
      ...other,
      sostType: sostType === PublishRecSostType.Rec,
      advantage: advantage === PublishRecAdvantage.Has,
      sogl: sogl === PublishRecSogl.Sent,
    };

    try {
      if (isExisting) {
        const upateModel: PublishRecTabUpdateModel = {
          ...newVals,
          ...profilesSet,
        };
        await updatePublishRecTab(upateModel).unwrap();
        toastSuccess('Публикация обновлена');
      } else {
        const createModel: PublishRecTabCreateModel = {
          ...newVals,
          ...profilesSet,
        };
        await createPublishRecTab(createModel);
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
      <PublishRecTabForm values={formValues} onSubmit={handleSubmit} />
    </div>
  );
};

export default PublishRecTabDetail;
