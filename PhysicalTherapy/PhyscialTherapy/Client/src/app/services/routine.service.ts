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

  public get(username : string) : Observable<Routine[]> {
    console.log("Entering getAllPatients in the server.");
    return this.http.get<Routine[]>(this.accessPointUrl + '/'+ username);
  }

  
  public getAll() : Observable<Routine[]> {
    console.log("Entering getAll from Routine to in the server.");
    return this.http.get<Routine[]>(this.accessPointUrl);
  }

  public getRecentRoutineCompletionsByTherapistId(therapistId : number) : Observable<Routine[]> {
    console.log("Entering getRecentFeedback in Routine Service");
    return this.http.get<Routine[]>(this.accessPointUrl + '/recent_feedback/' + therapistId);
  }

  public getLateRoutinesByTherapistId(therapistId : number) : Observable<Routine[]> {
    console.log("Entering getLatePatients in Routine Service");
    return this.http.get<Routine[]>(this.accessPointUrl + '/late_patients/' + therapistId);
  }

  public getSingleRoutineByRoutineId(routineId : number) : Observable<Routine[]> {
    console.log("Entering getSingleRoutineByRoutineId in RoutineService");
    return this.http.get<Routine[]>(this.accessPointUrl + '/routine_id/' + routineId);
  }

  public postRoutine(body) {
    return this.http.post<Routine>(this.accessPointUrl, body);
  }

  public putRoutine(body) {
    return this.http.put<Routine>(this.accessPointUrl, body);
  }
}