export const createDocumentFilename = (
  path: string,
  docType: string,
  customName: string
): string => {
  const dotSplit = path.split('.');
  const ext = dotSplit[dotSplit.length - 1];
  const separator = docType.length ? '_' : '';

  return `${docType}${separator}${customName}.${ext}`;
};
