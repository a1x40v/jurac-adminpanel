import React from 'react';

export enum ButtonType {
  primary = 'primary',
  warning = 'warning',
}

interface Props {
  label: string;
  type?: 'button' | 'submit' | 'reset';
  buttonType?: ButtonType;
  disabled?: boolean;
  isRounded?: boolean;
  onClick?: React.MouseEventHandler<HTMLButtonElement>;
}

type ButtonClasses = {
  [key in ButtonType]: {
    regular: string;
    hover: string;
  };
};

const BUTTON_CLASSES: ButtonClasses = {
  primary: {
    regular: 'bg-sky-700 text-white',
    hover: 'hover:bg-sky-600 hover:text-white',
  },
  warning: {
    regular: 'bg-red-700 text-white',
    hover: 'hover:bg-red-600',
  },
};

const Button: React.FC<Props> = ({
  label,
  type = 'button',
  buttonType = ButtonType.primary,
  disabled = false,
  isRounded = false,
  onClick = () => {},
}) => {
  const disabledClasses = disabled
    ? 'bg-gray-300 text-gray-400'
    : BUTTON_CLASSES[buttonType].regular;

  const hoverClasses = disabled ? '' : BUTTON_CLASSES[buttonType].hover;

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
