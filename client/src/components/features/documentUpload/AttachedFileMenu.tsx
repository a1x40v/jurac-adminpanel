import Button, { ButtonType } from '../../common/UI/inputs/Button';

interface Props {
  file: File;
  onCancel: () => void;
}

const AttachedFileMenu: React.FC<Props> = ({ file, onCancel }) => {
  return (
    <div className="flex justify-center items-center">
      <span className="mr-4">Файл "{file.name}" прикреплён</span>
      <Button
        label="Отменить"
        buttonType={ButtonType.warning}
        isRounded
        onClick={onCancel}
      />
    </div>
  );
};

export default AttachedFileMenu;
