import React from 'react';

interface Props {
  label: string;
  disabled?: boolean;
  isRounded?: boolean;
  onClick?: React.MouseEventHandler<HTMLButtonElement>;
}

const Button: React.FC<Props> = ({
  label,
  disabled = false,
  isRounded = false,
  onClick = () => {},
}) => {
  const disabledClasses = disabled
    ? 'bg-gray-300 text-gray-400'
    : 'bg-sky-700 text-white';

  const hoverClasses = disabled ? '' : 'hover:bg-sky-600 hover:text-white';

  const roundedClasses = isRounded ? 'rounded-xl' : '';

  return (
    <button
      className={`p-2 border-2 font-nanito ${roundedClasses} ${disabledClasses} ${hoverClasses}`}
      disabled={disabled}
      onClick={onClick}
    >
      {label}
    </button>
  );
};

export default Button;
