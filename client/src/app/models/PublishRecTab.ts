import { AbiturientTestType } from './Abiturient';
import { ChoiceProfile, ChoiceProfileSet } from './ChoiceProfile';

export type PublishRecTabPoints = {
  individ: number;
  rusPoint: number;
  obshPoint: number;
  historyPoint: number;
  foreignLanguagePoint: number;
  gpPoint: number;
  tgpPoint: number;
  upPoint: number;
  kpPoint: number;
  okpPoint: number;
  specPoint: number;
  sumPoints: number;
};

export type PublishRecTab = {
  id: number;
  userId: number;
  fullName: string;
  testType: AbiturientTestType;
  sogl: string;
  sostType: string;
  advantage: string;
  isPublished: boolean;
  comment: string;
} & PublishRecTabPoints &
  ChoiceProfileSet;

export type PublishRecTabUpdateModel = Omit<
  PublishRecTab,
  'id' | 'fullName' | 'sumPoints' | 'sogl' | 'sostType' | 'advantage'
> & { sogl: boolean; sostType: boolean; advantage: boolean };

export type PublishRecTabCreateModel = PublishRecTabUpdateModel;

export type PublishRecTabView = {
  id: number;
  userId: number;
  fullName: string;
  testType: AbiturientTestType;
  sogl: string;
  sostType: string;
  advantage: string;
  sumPoints: number;
  profiles: ChoiceProfile[];
  isPublished: boolean;
  comment: string;
};

export enum PublishRecSostType {
  Rec = 'Рекомендован',
  NotRec = 'Не рекомендован',
}

export enum PublishRecAdvantage {
  Has = 'Имеет',
  HasNot = 'Не имеет',
}

export enum PublishRecSogl {
  Sent = 'Подано',
  NotSent = 'Не подано',
}
