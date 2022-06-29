import { useCallback } from 'react';
import { Editor, RichUtils, EditorState } from 'draft-js';
import 'draft-js/dist/Draft.css';

import EditorControls from './EditorControls';

interface Props {
  value: EditorState;
  onChange: (state: EditorState) => void;
}

const styleMap = {
  FONT_SIZE_SMALL: {
    fontSize: 'small',
  },
  FONT_SIZE_MEDIUM: {
    fontSize: 'medium',
  },
  FONT_SIZE_LARGE: {
    fontSize: 'large',
  },
};

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

  // font sizes
  const onFontSmallClick = useCallback(() => {
    onChange(RichUtils.toggleInlineStyle(value, 'FONT_SIZE_SMALL'));
  }, [value]);

  const onFontMediumClick = useCallback(() => {
    onChange(RichUtils.toggleInlineStyle(value, 'FONT_SIZE_MEDIUM'));
  }, [value]);

  const onFontLargeClick = useCallback(() => {
    onChange(RichUtils.toggleInlineStyle(value, 'FONT_SIZE_LARGE'));
  }, [value]);

  const stylesControls = [
    { label: 'Жирный', onClick: onBoldClick },
    { label: 'Курсив', onClick: onItalicClick },
    { label: 'Подчеркнуть', onClick: onUnderlineClick },
  ];

  const sizesControls = [
    { label: 'Маленький', onClick: onFontSmallClick },
    { label: 'Средний', onClick: onFontMediumClick },
    { label: 'Большой', onClick: onFontLargeClick },
  ];

  return (
    <div>
      <div className="flex">
        <div className="mr-6">
          <EditorControls controls={stylesControls} />
        </div>
        <div>
          <EditorControls controls={sizesControls} />
        </div>
      </div>
      <div className="border-sky-700 border p-4">
        <Editor
          editorState={value}
          customStyleMap={styleMap}
          onChange={onChange}
        />
      </div>
    </div>
  );
};

export default HtmlEditor;
