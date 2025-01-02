import { UUIDTypes } from 'uuid';

export type Card = {
  id?: UUIDTypes;
  deckId: UUIDTypes;
  question: string;
  answer: string;
  lastReviewed: Date;
  lastStatus: RatingStatus;
  reviewCount: number;
};

export enum RatingStatus {
  Forgot = 1,
  Hard = 2,
  Good = 3,
  Easy = 4,
}
