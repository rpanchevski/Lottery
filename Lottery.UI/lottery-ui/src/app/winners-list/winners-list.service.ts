import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserCodeAward } from './winners-list.model';

@Injectable({
  providedIn: 'root',
})
export class WinnersListService {
  winnersUrl: string = "http://localhost:8599/api/lottery/getAllWinners";
  constructor(private http: HttpClient) { }

  getAllWinners() : Observable<Array<UserCodeAward>> {
      return this.http.get<Array<UserCodeAward>>(this.winnersUrl);
  }
}