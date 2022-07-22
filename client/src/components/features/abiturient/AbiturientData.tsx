import { useUpdateAbiturientMutation } from '../../../app/apiServices/abiturientService';
import { Abiturient, AbiturientUpdate } from '../../../app/models/Abiturient';
import { toastError, toastSuccess } from '../../../app/react-toasts';
import DocumentUploadWidget from '../documentUpload/DocumentUploadWidget';
import AbiturientForm from './AbiturientForm';

interface Props {
  abitur: Abiturient;
}

const AbiturientData: React.FC<Props> = ({ abitur }) => {
  const [updateAbiturient] = useUpdateAbiturientMutation();

  const handleSubmit = async (values: AbiturientUpdate) => {
    try {
      await updateAbiturient(values).unwrap();
      toastSuccess('Пользователь обновлён');
    } catch (err) {
      console.log(err);
      toastError('Что-то пошло не так');
    }
  };

  return (
    <div className="min-w-[1200px] font-nanito">
      <div>
        <AbiturientForm abitur={abitur} onSubmit={handleSubmit} />
        <DocumentUploadWidget userId={abitur.id} />
      </div>
    </div>
  );
};

export default AbiturientData;
