import { useCallback, useEffect, useState } from 'react';

import DocumentUploadForm from './DocumentUploadForm';
import DocumentUploadWidgetDropzone from './DocumentUploadWidgetDropzone';

interface Props {
  userId: number;
}

export type UploadedDocument = {
  file: File;
  preview?: string;
  docType: string;
  customName: string;
  ext: string;
};

const PREVIEW_EXTS = ['jpg', 'jpeg', 'png'];

const DocumentUploadWidget: React.FC<Props> = ({ userId }) => {
  const [doc, setDoc] = useState<UploadedDocument | null>();

  const handleDropFile = useCallback(
    (file: File) => {
      const dotSplit = file.name.split('.');
      const ext = dotSplit[dotSplit.length - 1];
      const doc: UploadedDocument = {
        file,
        ext,
        docType: '',
        customName: dotSplit.slice(0, -1).join('.'),
        preview: PREVIEW_EXTS.includes(ext)
          ? URL.createObjectURL(file)
          : undefined,
      };
      setDoc(doc);
    },
    [setDoc]
  );

  const disposePreview = () => {
    if (doc && doc.preview) {
      URL.revokeObjectURL(doc.preview);
    }
  };

  useEffect(() => {
    return disposePreview;
  }, []);

  return (
    <div className="mt-4">
      <h3>DocumentUploadWidget</h3>
      <div>
        {doc ? (
          <DocumentUploadForm userId={userId} doc={doc} />
        ) : (
          <DocumentUploadWidgetDropzone onDropFile={handleDropFile} />
        )}
      </div>
    </div>
  );
};

export default DocumentUploadWidget;
