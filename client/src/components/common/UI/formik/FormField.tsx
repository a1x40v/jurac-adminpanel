import FormikInputText from './FormikInputText';

const FormField: React.FC<{
  name: string;
  label: string | React.ReactElement;
  isFullWidth?: boolean;
}> = ({ name, label, isFullWidth }) => {
  return (
    <div className="flex items-center justify-between mb-6">
      <div className="mr-4">{label}:</div>
      <FormikInputText isFullWidth={isFullWidth} name={name} />
    </div>
  );
};

export default FormField;
