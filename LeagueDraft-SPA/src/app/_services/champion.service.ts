import { Injectable } from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ChampionInfo} from '../_models/champion-info';

@Injectable({
  providedIn: 'root'
})
export class ChampionService {
  private baseUrl = environment.apiUrl + 'champion/';
  private httpOptions = {
    headers: new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token')
    })
  };

  constructor(private http: HttpClient) { }

  getChampionsInfo(): Observable<ChampionInfo[]> {
    return this.http.get<ChampionInfo[]>(this.baseUrl, this.httpOptions);
  }
}
