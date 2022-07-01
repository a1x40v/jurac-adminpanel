import { useParams } from 'react-router-dom';
import dateFormat from 'dateformat';

import { useGetMessageQuery } from '../../../app/apiServices/emailMessageService';
import LoadingIndicator from '../../common/LoadingIndicator';
import { Link } from 'react-router-dom';

const EmailMessageDetail = () => {
  let { id } = useParams();
  const messageId = Number(id);

  const { data, isLoading, error } = useGetMessageQuery(messageId);

  if (error) {
    return <div>Не удалось загрузить email-сообщение с id = {messageId}.</div>;
  }

  if (isLoading || !data) {
    return (
      <div className="w-full">
        <LoadingIndicator />
      </div>
    );
  }

  return (
    <div className="min-w-[1200px] ml-[200px] py-6 font-nanito">
      <Link
        className=" text-sky-700 hover:underline"
        to={`/abiturients/${data.recipientId}`}
      >
        Вернуться к пользователю
      </Link>
      <div className="flex mt-6 justify-between items-center">
        <h1 className="text-xl font-bold">
          Письмо для <u>{data.recipientUsername}</u>
        </h1>
        <span className="font-bold">ID письма: {data.id}</span>
      </div>
      <div className="flex mt-6">
        <div className="mr-10">
          <span>Отправил:</span> <p>{data.senderUsername}</p>
        </div>
        <div className="mr-10">
          <span>Отправлено в:</span>
          <p>{dateFormat(new Date(data.sentAt), 'dd.mm.yy HH:MM')}</p>
        </div>
        <div className="mr-10">
          <span>На адрес:</span> <p>{data.recipientEmail}</p>
        </div>
        <div className="mr-10">
          <span>Тема:</span> <p>{data.subject}</p>
        </div>
      </div>
      <div className="relative mt-8 border-b border-sky-700 text-center">
        <span className="absolute top-0 right-[50%] px-4 bg-white -translate-y-[50%] translate-x-[50%]">
          Содержимое письма
        </span>
      </div>
      <div
        className="mt-4"
        dangerouslySetInnerHTML={{ __html: data.content }}
      ></div>
    </div>
  );
};

export default EmailMessageDetail;
