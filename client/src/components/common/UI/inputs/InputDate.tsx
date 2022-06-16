import dateFormat from 'dateformat';

interface Props {
  disabled?: boolean;
  value?: string;
  name?: string;
  onChange?: React.ChangeEventHandler<HTMLInputElement>;
  onBlur?: React.FocusEventHandler<HTMLInputElement>;
}

const InputDate: React.FC<Props> = ({
  name,
  value,
  disabled = false,
  onChange,
  onBlur,
}) => {
  const formatedVal = value ? dateFormat(new Date(value), 'yyyy-mm-dd') : '';

  return (
    <input
      type="date"
      pattern="dd-mm-yyyy"
      className="p-2 focus-visible:outline-sky-700"
      disabled={disabled}
      name={name}
      value={formatedVal}
      onChange={onChange}
      onBlur={onBlur}
    />
  );
};

export default InputDate;
