import { EditorState } from 'draft-js';
import { stateToHTML } from 'draft-js-export-html';
import { useState } from 'react';

import { useSendAbiturientEmailMutation } from '../../../app/apiServices/abiturientService';
import { toastError, toastSuccess } from '../../../app/react-toasts';
import Button from '../../common/UI/inputs/Button';
import InputText from '../../common/UI/inputs/InputText';
import HtmlEditor from '../../htmlEditor/HtmlEditor';

interface Props {
  userEmail: string;
}

const AbiturientEmail: React.FC<Props> = ({ userEmail }) => {
  const [sendEmail, { isLoading }] = useSendAbiturientEmailMutation();
  const [editorState, setEditorState] = useState(EditorState.createEmpty());
  const [subject, setSubject] = useState(
    'Сообщение от приемной комиссии СПбЮА'
  );

  const handleSubmit = async () => {
    const content = stateToHTML(editorState.getCurrentContent());
    console.log(content);

    try {
      await sendEmail({
        userEmail: 'a1x40v@gmail.com',
        subject,
        content,
      }).unwrap();
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

export default AbiturientEmail;
