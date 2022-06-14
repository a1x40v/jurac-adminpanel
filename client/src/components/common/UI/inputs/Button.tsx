import React from 'react';

interface Props {
  label: string;
  type?: 'button' | 'submit' | 'reset';
  disabled?: boolean;
  isRounded?: boolean;
  onClick?: React.MouseEventHandler<HTMLButtonElement>;
}

const Button: React.FC<Props> = ({
  label,
  type = 'button',
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
      type={type}
      disabled={disabled}
      onClick={onClick}
    >
      {label}
    </button>
  );
};

export default Button;
