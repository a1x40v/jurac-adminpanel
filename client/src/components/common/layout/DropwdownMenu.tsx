import { useState } from 'react';

interface Props {
  label: string | React.ReactNode;
  isActiveDefault?: boolean;
  children?: React.ReactNode;
}

const DropwdownMenu: React.FC<Props> = ({
  children,
  label,
  isActiveDefault = false,
}) => {
  const [active, setActive] = useState(isActiveDefault);

  return (
    <div className="flex flex-col items-start">
      <div
        className="flex items-center py-2 px-4 mb-4 text-white rounded-lg cursor-pointer bg-sky-700"
        onClick={() => setActive((state) => !state)}
      >
        <div
          className={`border-solid border-x-transparent border-x-8 mr-3 border-t-white border-t-8 ${
            active ? '' : '-rotate-90'
          }`}
        ></div>
        <div>{label}</div>
      </div>
      <div className={`${!active ? 'hidden' : ''}`}>{children}</div>
    </div>
  );
};

export default DropwdownMenu;
