import { UUIDTypes } from 'uuid';
import { Card } from './Card';

export type Deck = {
  id?: UUIDTypes;
  deckName: string;
  description: string;
  cardCount: number;
  flashcards?: Card[];
};
