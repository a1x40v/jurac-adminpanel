export interface PublishRecTabMod {
  id: number;
  abiturientId: number;
  createdAt: string;
  author: string;
  type: PublishRecTabModType;
  studentName: string;
}

export enum PublishRecTabModType {
  Created = 0,
  Updated = 1,
  Deleted = 2,
  Showed = 3,
  Hidden = 4,
}
