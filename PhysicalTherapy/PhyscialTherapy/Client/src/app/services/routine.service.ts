import { apiEndpoint } from '../globals'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Routine } from '../models/Routine';


@Injectable()
export class RoutineService {
  private headers: HttpHeaders;
  private accessPointUrl: string = `${apiEndpoint}/routines`;

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }

  // public get(username : string) : Observable<Routine> {
  //   console.log("Entering getAllPatients in the server.");
  //   return this.http.get<Routine>(this.accessPointUrl);
  // }

    // test method 
  public getAll() : Observable<Routine[]> {
    console.log("Entering getAll from Routine to in the server.");
    return this.http.get<Routine[]>(this.accessPointUrl);
  }

  // public add(payload) {
  //   return this.http.post(this.accessPointUrl, payload, {headers: this.headers});
  // }

  // public remove(payload) {
  //   return this.http.delete(this.accessPointUrl + '/' + payload.id, {headers: this.headers});
  // }

  // public update(payload) {
  //   return this.http.put(this.accessPointUrl + '/' + payload.id, payload, {headers: this.headers});
  // }
}