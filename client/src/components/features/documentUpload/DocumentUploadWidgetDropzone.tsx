import { useCallback } from 'react';
import { useDropzone } from 'react-dropzone';

interface Props {
  onDropFile: (file: File) => void;
}

const DocumentUploadWidgetDropzone: React.FC<Props> = ({ onDropFile }) => {
  const onDrop = useCallback(
    (acceptedFiles: File[]) => {
      onDropFile(acceptedFiles[0]);
    },
    [onDropFile]
  );

  const { getRootProps, getInputProps, isDragActive } = useDropzone({ onDrop });

  const borderClasses = isDragActive ? 'border-green-700' : 'border-gray-400';

  return (
    <div
      {...getRootProps()}
      className={`border-2 border-dashed  rounded-md h-[200px] flex items-center justify-center ${borderClasses}`}
    >
      <input {...getInputProps()} />

      {isDragActive ? (
        <p>Бросайте файл сюда ...</p>
      ) : (
        <p>
          Перетащите файл сюда или кликните, чтобы выбрать файл в Вашей системе
        </p>
      )}
    </div>
  );
};

export default DocumentUploadWidgetDropzone;
