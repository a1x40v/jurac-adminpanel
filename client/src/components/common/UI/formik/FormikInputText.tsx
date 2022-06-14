import { useField } from 'formik';
import InputText from '../inputs/InputText';

interface Props {
  name: string;
  type?: React.HTMLInputTypeAttribute;
}

const FormikInputText: React.FC<Props> = ({ name, type }) => {
  const [field, meta] = useField(name);
  const isError = meta.touched && !!meta.error;

  return (
    <div className="relative font-nanito">
      <InputText isError={isError} type={type} {...field} />
      {isError ? (
        <span className="absolute left-0 w-full text-center text-red-700 -bottom-6">
          {meta.error}
        </span>
      ) : null}
    </div>
  );
};

export default FormikInputText;
