import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }

  postUser(username:string): void {
    this.http.post<string>(environment.baseUrl + "/login/Login/", username);
  }
}
