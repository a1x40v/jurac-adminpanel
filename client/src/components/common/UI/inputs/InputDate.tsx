interface Props {
  disabled?: boolean;
  value?: string;
  onChange?: (date: string) => void;
}

const InputDate: React.FC<Props> = ({
  value,
  disabled = false,
  onChange = () => {},
}) => {
  return (
    <input
      type="date"
      pattern="dd-mm-yyyy"
      className="p-2 focus-visible:outline-sky-700"
      disabled={disabled}
      value={value || ''}
      onChange={(evt) => onChange(evt.target.value)}
    />
  );
};

export default InputDate;
