import { Injectable } from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {SummonerWithRankedInfo} from '../_models/summoner-with-ranked-info/summoner-with-ranked-info';
import {MatchInfo} from "../_models/match-info/match-info";

@Injectable({
  providedIn: 'root'
})
export class SummonerService {
  private baseUrl = environment.apiUrl + 'summoner/';
  private httpOptions = {
    headers: new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token')
    })
  };

  constructor(private http: HttpClient) { }

  getSummonerInfo(): Observable<SummonerWithRankedInfo> {
    return this.http.get<SummonerWithRankedInfo>(this.baseUrl + 'SummonerInfo/?region=EUNE&summonerName=Woolfer', this.httpOptions);
  }

  getMatchlistForSummoner(accountId: string): Observable<MatchInfo[]> {
    return this.http.get<MatchInfo[]>(this.baseUrl + `Matches/?region=EUNE&accountId=${accountId}`, this.httpOptions);
  }
}
