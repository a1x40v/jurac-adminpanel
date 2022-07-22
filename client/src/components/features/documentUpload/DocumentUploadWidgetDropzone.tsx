import { useCallback } from 'react';
import { useDropzone } from 'react-dropzone';

interface Props {
  onDropFile: (file: File) => void;
}

const dzStyles = {
  border: 'dashed 3px #eee',
  borderColor: '#eee',
  borderRadius: '5px',
  paddingTop: '30px',
  textAlign: 'center' as 'center',
  height: 200,
};

const dzActive = {
  borderColor: 'green',
};

const DocumentUploadWidgetDropzone: React.FC<Props> = ({ onDropFile }) => {
  const onDrop = useCallback(
    (acceptedFiles: File[]) => {
      onDropFile(acceptedFiles[0]);
    },
    [onDropFile]
  );

  const { getRootProps, getInputProps, isDragActive } = useDropzone({ onDrop });

  return (
    <div
      {...getRootProps()}
      style={isDragActive ? { ...dzStyles, ...dzActive } : dzStyles}
    >
      <input {...getInputProps()} />
      {isDragActive ? (
        <p>Drop the files here ...</p>
      ) : (
        <p>Drag 'n' drop some files here, or click to select files</p>
      )}
    </div>
  );
};

export default DocumentUploadWidgetDropzone;
