import { ChoiceProfile, ChoiceProfileSet } from './ChoiceProfile';

export type PublishTab = {
  id: number;
  userId: number;
  fullName: string;
  individualStr: string;
  testType: string;
} & ChoiceProfileSet;

export interface PublishTabView {
  id: number;
  userId: number;
  fullName: string;
  individualStr: string;
  testType: string;
  profiles: ChoiceProfile[];
}
