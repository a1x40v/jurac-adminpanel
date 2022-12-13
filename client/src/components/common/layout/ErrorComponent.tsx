interface Props {
  label: string;
}

const ErrorComponent: React.FC<Props> = ({ label }) => {
  return (
    <div className="flex justify-center items-center w-full text-lg">
      <div className="flex flex-col items-center">
        <span className="font-bold">Ошибка</span>
        <span>{label}</span>
      </div>
    </div>
  );
};

export default ErrorComponent;
