import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IGame } from 'src/app/models/igame';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  constructor(private http: HttpClient) { }

  getNewGame() {
    return this.http.get<IGame[]>(environment.baseUrl + "/Game/getNewGameObject");
  }

  getRanking() {
    return this.http.get(environment.baseUrl + "/Game/getLeaderboard");
  }
}
