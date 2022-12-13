import React, { useState } from 'react';
import Button, { ButtonType } from './Button';

interface Props {
  label: string;
  confirmationLabel: string;
  type?: 'button' | 'submit' | 'reset';
  buttonType?: ButtonType;
  disabled?: boolean;
  isRounded?: boolean;
  onClick?: () => void;
}

const ConfirmationButton: React.FC<Props> = ({
  confirmationLabel,
  disabled,
  onClick = () => {},
  ...props
}) => {
  const [showed, setShowed] = useState<boolean>(false);
  const handleClick: React.MouseEventHandler<HTMLButtonElement> = () => {
    setShowed(true);
  };

  return (
    <div className="relative inline-block">
      <Button onClick={handleClick} disabled={showed || disabled} {...props} />
      {showed && (
        <div className="absolute top-0 right-0 translate-x-full">
          <div className="flex items-center ml-2">
            <span className="mr-1">{confirmationLabel}</span>
            <Button
              label="Да"
              buttonType={ButtonType.primary}
              isRounded
              onClick={() => {
                onClick();
                setShowed(false);
              }}
            />
            <Button
              label="Нет"
              buttonType={ButtonType.warning}
              isRounded
              onClick={() => setShowed(false)}
            />
          </div>
        </div>
      )}
    </div>
  );
};

export default ConfirmationButton;
