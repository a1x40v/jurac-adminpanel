import { useGetRecipientMessagesQuery } from '../../../app/apiServices/emailMessageService';
import LoadingIndicator from '../../common/LoadingIndicator';
import EmailMessagesTable from '../email/EmailMessagesTable';
import EmailEditor from '../email/EmailEditor';

interface Props {
  userId: number;
  userEmail: string;
}

const AbiturientEmail: React.FC<Props> = ({ userId, userEmail }) => {
  const { data, isLoading } = useGetRecipientMessagesQuery(userId);

  if (!data || isLoading) {
    return <LoadingIndicator />;
  }

  return (
    <div>
      <EmailMessagesTable messages={data} />
      <h2 className="my-4 font-bold text-lg text-center">Отправить письмо</h2>
      <EmailEditor
        userId={userId}
        userEmail={userEmail}
        defaultSubject="Сообщение от приемной комиссии СПбЮА"
      />
    </div>
  );
};

export default AbiturientEmail;
