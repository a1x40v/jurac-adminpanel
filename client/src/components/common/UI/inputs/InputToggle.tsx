interface Props {
  name: string;
  value: boolean;
  onChange: React.ChangeEventHandler<HTMLInputElement> | undefined;
}

const InputToggle: React.FC<Props> = ({ name, value, onChange }) => {
  return (
    <label className="relative inline-block w-16 h-9">
      <input
        type="checkbox"
        className="opacity-0 w-0 h-0 peer"
        name={name}
        checked={value}
        onChange={onChange}
      />
      <span
        className="absolute cursor-pointer top-0 left-0 right-0 bottom-0 bg-gray-300 rounded-full
          transition-colors duration-300
          before:absolute before:content-[''] before:h-7 before:w-7 before:left-1 before:bottom-1 before:bg-white before:rounded-full
          before:transition-transform before:duration-300
          peer-checked:bg-sky-700 peer-checked:before:translate-x-7"
      ></span>
    </label>
  );
};

export default InputToggle;
