import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class CredentialService {
    private headers: HttpHeaders;
    private accessPointUrl: string = 'http://localhost:64496/api/Credentials';
  
    constructor(private http: HttpClient) {
      this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
    }

    public getUser(username) {
        return this.http.get(`${this.accessPointUrl}/${username}`, {headers: this.headers});
    }
}