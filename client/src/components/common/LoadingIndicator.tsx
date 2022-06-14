import ScaleLoader from 'react-spinners/ScaleLoader';

interface Props {
  label?: string;
}

const LoadingIndicator: React.FC<Props> = ({ label = 'Загрузка...' }) => {
  return (
    <div className="flex flex-col items-center mt-20 font-nanito">
      <span className="mb-4">{label}</span>
      <ScaleLoader color="rgb(12,74,110)" />
    </div>
  );
};

export default LoadingIndicator;
