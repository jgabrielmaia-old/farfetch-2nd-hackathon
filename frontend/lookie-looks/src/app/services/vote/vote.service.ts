import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IVote } from 'src/app/models/ivote';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class VoteService {

  constructor(private http: HttpClient) { }

  postVote(vote: IVote) {
    this.http.post(environment.baseUrl + "/Game/SubmitVote/", vote);
  }

}