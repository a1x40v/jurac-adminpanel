import {
  AbiturientTestType,
  DocExistStatus,
  DocSendStatus,
} from '../models/Abiturient';
import { ChoiceProfile } from '../models/ChoiceProfile';
import {
  PublishRecAdvantage,
  PublishRecSogl,
  PublishRecSostType,
} from '../models/PublishRecTab';

export const SEND_STATUS_DESC: { [key in DocSendStatus]: string } = {
  error: 'Неверные данные',
  no: 'Не поданы',
  send: 'Поданы',
  working: 'В работе',
  success: 'Обработаны',
  back: 'Отозваны',
};

export const EXIST_STATUS_DESC: { [key in DocExistStatus]: string } = {
  exist: 'Есть документы',
  notExist: 'Документов нет',
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

export const REC_SOST_TYPES: PublishRecSostType[] = [
  PublishRecSostType.Rec,
  PublishRecSostType.NotRec,
];

export const REC_ADVANTAGES: PublishRecAdvantage[] = [
  PublishRecAdvantage.Has,
  PublishRecAdvantage.HasNot,
];

export const REC_SOGLS: PublishRecSogl[] = [
  PublishRecSogl.Sent,
  PublishRecSogl.NotSent,
];
