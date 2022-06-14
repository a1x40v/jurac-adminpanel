import { Pagination } from './Pagination';

export enum AbtSortableField {
  Id = 'id',
  FirstName = 'firstName',
  LastName = 'lastName',
  DateJoined = 'dateJoined',
  Phone = 'phoneNumber',
  Email = 'email',
  Status = 'sendingStatus',
}

export enum DocSendStatus {
  Error = 'error',
  No = 'no',
  Send = 'send',
  Working = 'working',
  Success = 'success',
  Back = 'back',
}

export interface Abiturient {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  dateJoined: string;
  lastLogin: string;
  patronymic: string;
  dateOfBirth: string;
  phoneNumber: string;
  sendingStatus: DocSendStatus;
  completeFlag: boolean;
  agreementFlag: boolean;
  workFlag: boolean;
  successFlag: boolean;
  address: string;
  commentAdmin: string;
  dateOfDoc: string;
  nameUz: string;
  passport: string;
  snils: string;
  message: string;
  documents: AbiturDocument[];
}

export type AbiturientUpdate = Omit<Abiturient, 'documents'>;
export interface AbiturDocument {
  id: number;
  datePub: Date;
  nameDoc: string;
  doc: string;
}

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
