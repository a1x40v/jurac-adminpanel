import { ReactNode } from 'react';

interface Props {
  children?: ReactNode;
}

const MiddleLineLabel: React.FC<Props> = ({ children = '' }) => {
  const line = (
    <div className="relative grow">
      <div className="absolute left-0 top-[50%] bg-sky-900 h-[1px] w-full"></div>
    </div>
  );

  return (
    <div className="flex w-full">
      {line}
      <div className="px-2">{children}</div>
      {line}
    </div>
  );
};

export default MiddleLineLabel;
