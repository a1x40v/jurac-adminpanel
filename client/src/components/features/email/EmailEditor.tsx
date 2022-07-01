import { ContentState, EditorState } from 'draft-js';
import { stateToHTML } from 'draft-js-export-html';
import { useState } from 'react';

import { useSendEmailMutation } from '../../../app/apiServices/emailMessageService';
import { toastError, toastSuccess } from '../../../app/react-toasts';
import Button from '../../common/UI/inputs/Button';
import InputText from '../../common/UI/inputs/InputText';
import HtmlEditor from '../../htmlEditor/HtmlEditor';

interface Props {
  userId: number;
  userEmail: string;
  defaultSubject: string;
}

const EmailEditor: React.FC<Props> = ({
  userEmail,
  userId,
  defaultSubject,
}) => {
  const [sendEmail, { isLoading }] = useSendEmailMutation();
  const [editorState, setEditorState] = useState(EditorState.createEmpty());
  const [subject, setSubject] = useState(defaultSubject);

  const handleSubmit = async () => {
    const content = stateToHTML(editorState.getCurrentContent());

    try {
      await sendEmail({
        userId,
        subject,
        content: content.replace(/\r?\n|\r/g, ''),
      }).unwrap();

      setEditorState(
        EditorState.push(
          editorState,
          ContentState.createFromText(''),
          'remove-range'
        )
      );
      setSubject(defaultSubject);

      toastSuccess('Отправлено');
    } catch (err) {
      console.log(err);
      toastError('Отправка не удалась');
    }
  };

  return (
    <div className="max-w-[1200px]">
      <div className="flex flex-col mb-4">
        <span>Адресат:</span>
        <span className="font-bold">{userEmail}</span>
      </div>
      <label className="flex flex-col">
        <span className="mb-1">Тема:</span>
        <InputText
          value={subject}
          onChange={(evt) => setSubject(evt.target.value)}
        />
      </label>
      <div className="mt-8">
        <HtmlEditor value={editorState} onChange={setEditorState} />
      </div>
      <div className="mt-4">
        <Button
          disabled={isLoading}
          label={isLoading ? 'Отправка...' : 'Отправить'}
          onClick={handleSubmit}
        />
      </div>
    </div>
  );
};

export default EmailEditor;
