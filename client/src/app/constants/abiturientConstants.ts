import { AbiturientTestType, DocSendStatus } from '../models/Abiturient';
import { ChoiceProfile } from '../models/ChoiceProfile';

export const SEND_STATUS_DESC: { [key in DocSendStatus]: string } = {
  error: 'Неверные данные',
  no: 'Не поданы',
  send: 'Поданы',
  working: 'В работе',
  success: 'Обработаны',
  back: 'Отозваны',
};

export const CHOICE_PROFILES = [
  ChoiceProfile.BakOfoUp,
  ChoiceProfile.BakZfoUp,
  ChoiceProfile.BakOzfoUp,
  ChoiceProfile.BakOfoGp,
  ChoiceProfile.BakZfoGp,
  ChoiceProfile.BakOzfoGp,
  ChoiceProfile.SpecOfoSd,
  ChoiceProfile.MagOfoPo,
  ChoiceProfile.MagZfoPo,
  ChoiceProfile.MagOfoTp,
  ChoiceProfile.MagZfoTp,
  ChoiceProfile.AspOfoGp,
  ChoiceProfile.AspOfoUgp,
];

export const SEND_STATUSES: DocSendStatus[] = [
  DocSendStatus.Error,
  DocSendStatus.No,
  DocSendStatus.Send,
  DocSendStatus.Working,
  DocSendStatus.Success,
  DocSendStatus.Back,
];

export const TEST_TYPES: AbiturientTestType[] = [
  AbiturientTestType.Ege,
  AbiturientTestType.Vi,
];
