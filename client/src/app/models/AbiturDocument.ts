export interface AbiturDocument {
  id: number;
  datePub: string;
  nameDoc: string;
  doc: string;
}

export type CreateDocumentModel = {
  userId: number;
  file: File;
};

export type UpdateDocumentModel = {
  id: number;
};
