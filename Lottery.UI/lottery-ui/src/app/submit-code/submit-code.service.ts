import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserCode, Award } from './submit-code.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CodeService {
  submitCodeUrl: string = "http://localhost:8599/api/lottery/submitCode";
  constructor(private http: HttpClient) { }

  submitCode(userCode: UserCode) : Observable<Award> {
      return this.http.post<Award>(this.submitCodeUrl, userCode);
  }
}