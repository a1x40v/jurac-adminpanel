import { useField } from 'formik';

import InputText from '../inputs/InputText';

interface Props {
  name: string;
  type?: React.HTMLInputTypeAttribute;
  placeholder?: string;
  isFullWidth?: boolean;
}

const FormikInputText: React.FC<Props> = ({
  name,
  type,
  placeholder,
  isFullWidth = false,
}) => {
  const [field, meta] = useField(name);
  const isError = meta.touched && !!meta.error;

  const style = {
    width: isFullWidth ? '100%' : 'auto',
    maxWidth: isFullWidth ? '900px' : 'auto',
  };

  return (
    <div className="relative font-nanito" style={style}>
      <InputText
        type={type}
        placeholder={placeholder}
        isError={isError}
        styles={isFullWidth ? { width: '100%' } : undefined}
        {...field}
      />
      {isError ? (
        <span className="absolute left-0 w-full text-center text-red-700 -bottom-6">
          {meta.error}
        </span>
      ) : null}
    </div>
  );
};

export default FormikInputText;
