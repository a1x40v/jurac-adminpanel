import { DocSendStatus } from '../models/Abiturient';

export const SEND_STATUS_DESC: { [key in DocSendStatus]: string } = {
  error: 'Неверные данные',
  no: 'Не поданы',
  send: 'Поданы',
  working: 'В работе',
  success: 'Обработаны',
  back: 'Отозваны',
};
