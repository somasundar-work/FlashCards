import { Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { DecksComponent } from './features/decks/decks.component';
import { ReviewsComponent } from './features/reviews/reviews.component';
import { SettingsComponent } from './features/settings/settings.component';
import { CardsComponent } from './features/cards/cards.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'decks', component: DecksComponent },
  { path: 'cards', component: CardsComponent },
  { path: 'reviews', component: ReviewsComponent },
  { path: 'settings', component: SettingsComponent },
  { path: '**', redirectTo: 'error/not-found', pathMatch: 'full' },
];
