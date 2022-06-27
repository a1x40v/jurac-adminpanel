import { CSSProperties } from 'react';

interface Props {
  name?: string;
  placeholder?: string;
  value: string;
  styles?: CSSProperties;
  type?: React.HTMLInputTypeAttribute;
  onChange?: React.ChangeEventHandler<HTMLInputElement>;
  onBlur?: React.FocusEventHandler<HTMLInputElement>;
  isError?: boolean;
}

const InputText: React.FC<Props> = ({
  value,
  name,
  placeholder,
  isError = false,
  type = 'text',
  styles,
  onChange,
  onBlur,
}) => {
  const errorClasses = isError
    ? 'border-red-700 focus-visible:outline-red-700'
    : 'border-sky-700 focus-visible:outline-sky-900';

  return (
    <input
      className={`py-2 px-4 border ${errorClasses}`}
      placeholder={placeholder}
      style={styles}
      type={type}
      name={name}
      value={value}
      onChange={onChange}
      onBlur={onBlur}
    />
  );
};

export default InputText;
