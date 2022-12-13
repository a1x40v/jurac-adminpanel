export interface AbiturDocument {
  id: number;
  userId: number;
  datePub: string;
  nameDoc: string;
  doc: string;
}

export type CreateDocumentModel = {
  userId: number;
  fileName: string;
  docType: string;
  file: File;
};

export type UpdateDocumentModel = {
  id: number;
  fileName: string;
  docType: string;
  file?: File;
};

export type UploadedDocument = {
  file?: File;
  docType: string;
  customName: string;
};
