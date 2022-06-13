import React from 'react';

interface Props {
  isActive?: boolean;
  isDisabled?: boolean;
  label: string;
  onClick: () => void;
}

const PaginationButton: React.FC<Props> = ({
  isActive,
  isDisabled,
  label,
  onClick = () => {},
}) => {
  const hoverClasses =
    isActive || isDisabled ? '' : 'hover:bg-sky-700 hover:text-white';

  const activeClasses = isActive
    ? 'bg-sky-700 text-white '
    : `bg-white ${isDisabled ? 'text-gray-400' : 'text-sky-700'}`;

  return (
    <button
      className={`px-3 py-2 ${activeClasses} ${hoverClasses}`}
      disabled={isDisabled}
      onClick={onClick}
    >
      {label}
    </button>
  );
};

export default PaginationButton;
