import { useCallback } from 'react';
import { Editor, RichUtils, EditorState } from 'draft-js';
import 'draft-js/dist/Draft.css';

import EditorControls from './EditorControls';

interface Props {
  value: EditorState;
  onChange: (state: EditorState) => void;
}

const HtmlEditor: React.FC<Props> = ({ value, onChange }) => {
  // font styles
  const onBoldClick = useCallback(() => {
    onChange(RichUtils.toggleInlineStyle(value, 'BOLD'));
  }, [value]);

  const onItalicClick = useCallback(() => {
    onChange(RichUtils.toggleInlineStyle(value, 'ITALIC'));
  }, [value]);

  const onUnderlineClick = useCallback(() => {
    onChange(RichUtils.toggleInlineStyle(value, 'UNDERLINE'));
  }, [value]);

  const stylesControls = [
    { label: 'Жирный', onClick: onBoldClick },
    { label: 'Курсив', onClick: onItalicClick },
    { label: 'Подчеркнуть', onClick: onUnderlineClick },
  ];

  return (
    <div>
      <div className="flex">
        <div className="mr-6">
          <EditorControls controls={stylesControls} />
        </div>
      </div>
      <div className="border-sky-700 border p-4">
        <Editor editorState={value} onChange={onChange} />
      </div>
    </div>
  );
};

export default HtmlEditor;
