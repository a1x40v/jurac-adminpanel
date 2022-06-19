import { AbiturientTestType } from './Abiturient';
import { ChoiceProfile, ChoiceProfileSet } from './ChoiceProfile';

export type PublishTab = {
  id: number;
  userId: number;
  fullName: string;
  individualStr: string;
  testType: AbiturientTestType;
} & ChoiceProfileSet;

export type PublishTabUpdateModel = Omit<PublishTab, 'id' | 'fullName'>;

export type PublishTabCreateModel = PublishTabUpdateModel;

export interface PublishTabView {
  id: number;
  userId: number;
  fullName: string;
  individualStr: string;
  testType: AbiturientTestType;
  profiles: ChoiceProfile[];
}
