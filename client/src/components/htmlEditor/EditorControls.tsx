import React from 'react';

interface EditorControl {
  label: string;
  onClick: () => void;
}

interface Props {
  controls: EditorControl[];
}

const EditorControls: React.FC<Props> = ({ controls }) => {
  return (
    <div className="flex mb-2 px-4">
      {controls.map(({ label, onClick }, idx) => (
        <button
          key={idx}
          className="mr-4 last:mr-0 hover:text-sky-700"
          onClick={onClick}
        >
          {label}
        </button>
      ))}
    </div>
  );
};

export default EditorControls;
