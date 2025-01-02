import { inject, Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { DeckParams } from '../../../shared/models/deckParams';
import { Deck } from '../../../shared/models/Deck';
import { Pagination } from '../../../shared/models/pagination';

@Injectable({
  providedIn: 'root',
})
export class DecksService {
  private baseUrl = environment.apiUrl;
  private http = inject(HttpClient);

  getDecks(deckParams: DeckParams) {
    let params = new HttpParams();
    if (deckParams.sort) {
      params = params.append('sort', deckParams.sort);
    }
    params = params.append('pageIndex', deckParams.pageNumber);
    params = params.append('pageSize', deckParams.pageSize);
    if (deckParams.search && deckParams.search !== '') {
      params = params.append('search', deckParams.search);
    }
    return this.http.get<Pagination<Deck>>(this.baseUrl + 'decks', {
      params,
    });
  }
}
