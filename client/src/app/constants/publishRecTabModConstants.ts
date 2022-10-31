import { PublishRecTabModType } from '../models/PublishRecTabMod';

export const PUBLISH_REC_MOD_DESC: { [key in PublishRecTabModType]: string } = {
  [PublishRecTabModType.Created]: 'Создана',
  [PublishRecTabModType.Updated]: 'Обновлена',
  [PublishRecTabModType.Deleted]: 'Удалена',
  [PublishRecTabModType.Showed]: 'Отображена',
  [PublishRecTabModType.Hidden]: 'Скрыта',
};
