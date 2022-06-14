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
  return (
    <input
      type="date"
      pattern="dd-mm-yyyy"
      className="p-2 focus-visible:outline-sky-700"
      disabled={disabled}
      name={name}
      value={value || ''}
      onChange={onChange}
      onBlur={onBlur}
    />
  );
};

export default InputDate;
