export interface CreateEmailMessageModel {
  userId: number;
  subject: string;
  content: string;
}

export interface EmailMessage {
  id: number;
  subject: string;
  content: string;
  recipientId: number;
  senderId: number;
  senderUsername: string;
  recipientUsername: string;
  sentAt: string;
  recipientEmail: string;
}

export interface EmailMessageView extends EmailMessage {
  contentText: string;
}
