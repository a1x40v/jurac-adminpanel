import {
  CreateEmailMessageModel,
  EmailMessage,
  EmailMessageView,
} from '../models/EmailMessage';
import { baseApi, CacheTagType } from './baseService';

const transformMessage = (mes: EmailMessage): EmailMessageView => {
  const MAX_CONTENT_LENGTH = 25;
  let contentText = mes.content.replace(/(<([^>]+)>)/gi, '');

  return {
    ...mes,
    sentAt: mes.sentAt.endsWith('Z') ? mes.sentAt : `${mes.sentAt}Z`,
    contentText:
      contentText.length <= MAX_CONTENT_LENGTH
        ? contentText
        : `${contentText.slice(0, MAX_CONTENT_LENGTH).trim()}...`,
  };
};

export const emailMessageApi = baseApi.injectEndpoints({
  endpoints: (builder) => ({
    getRecipientMessages: builder.query<EmailMessageView[], number>({
      query: (userId) => `email/users/${userId}`,
      transformResponse: (rawResult: EmailMessage[]) =>
        rawResult.map(transformMessage),
      providesTags: (result) =>
        result
          ? [
              ...result.map(
                ({ id }) => ({ id, type: CacheTagType.EmailMessage } as const)
              ),
              { type: CacheTagType.EmailMessage, id: 'LIST' },
            ]
          : [{ type: CacheTagType.EmailMessage, id: 'LIST' }],
    }),
    getMessage: builder.query<EmailMessageView, number>({
      query: (id) => `email/${id}`,
      transformResponse: (rawResult: EmailMessage) =>
        transformMessage(rawResult),
      providesTags: (result) =>
        result ? [{ id: result.id, type: CacheTagType.EmailMessage }] : [],
    }),
    sendEmail: builder.mutation<void, CreateEmailMessageModel>({
      query: (email) => ({
        url: 'email',
        method: 'POST',
        body: email,
      }),
      invalidatesTags: [CacheTagType.EmailMessage],
    }),
  }),
});

export const {
  useGetRecipientMessagesQuery,
  useGetMessageQuery,
  useSendEmailMutation,
} = emailMessageApi;
