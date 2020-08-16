import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {ChampionInfo} from "../_models/ChampionInfo";

@Injectable({
  providedIn: 'root'
})
export class ChampionService {
  baseUrl = environment.apiUrl + 'champion/'

  constructor(private http: HttpClient) { }

  getChampionsInfo(): Observable<ChampionInfo[]> {
    return this.http.get<ChampionInfo[]>(this.baseUrl);
  }
}
