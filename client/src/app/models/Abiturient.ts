import { ChoiceProfile } from './ChoiceProfile';
import { Pagination } from './Pagination';

export enum AbtSortableField {
  Id = 'id',
  Username = 'username',
  FirstName = 'firstName',
  LastName = 'lastName',
  DateJoined = 'dateJoined',
  Phone = 'phoneNumber',
  Email = 'email',
  Status = 'sendingStatus',
  NewestDocumentDate = 'newestDocumentDate',
}

export enum DocSendStatus {
  Error = 'error',
  No = 'no',
  Send = 'send',
  Working = 'working',
  Success = 'success',
  Back = 'back',
}

export enum DocExistStatus {
  Exist = 'exist',
  NotExist = 'notExist',
}

export enum AbiturientTestType {
  Ege = 'ЕГЭ',
  Vi = 'Вступительные испытания',
}

export interface Abiturient {
  id: number;
  username: string;
  firstName: string;
  lastName: string;
  email: string;
  dateJoined: string;
  lastLogin: string;
  patronymic: string;
  dateOfBirth: string;
  phoneNumber: string;
  sendingStatus: DocSendStatus;
  completeFlag: boolean; // Документы отправлены
  agreementFlag: boolean; // Соглашение
  workFlag: boolean; // Взят в работу
  successFlag: boolean; // Отработан
  address: string;
  commentAdmin: string;
  dateOfDoc: string;
  nameUz: string;
  passport: string;
  snils: string;
  newestDocumentDate: string | null;
  documentsAmount: number;
  choicesProfiles: ChoiceProfile[];
}

export type AbiturientUpdate = Omit<
  Abiturient,
  'documents' | 'dateJoined' | 'lastLogin' | 'newestDocumentDate'
>;

export interface AbiturientListVm {
  users: Abiturient[];
  pagination: Pagination;
}

export interface ExportedAbiturient {
  id: number;
  firstName: string;
  lastName: string;
  patronymic: string;
  dateOfBirth: string;
  nameUz: string;
  address: string;
  snils: string;
}
