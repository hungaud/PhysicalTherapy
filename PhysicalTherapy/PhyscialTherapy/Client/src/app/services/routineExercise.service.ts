import { apiEndpoint } from '../globals'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RoutineExercise } from '../models/RoutineExercise';

@Injectable()
export class RoutineExerciseService {
    private headers: HttpHeaders;
    private accessPointUrl: string = `${apiEndpoint}/RoutineExercises`;
  
    constructor(private http: HttpClient) {
      this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
    }

    public getRoutineExercises() : Observable<RoutineExercise[]> {
        return this.http.get<RoutineExercise[]>(`${this.accessPointUrl}`);
    }

    public postRoutineExercise(body) {
        return this.http.post<RoutineExercise>(`${this.accessPointUrl}`, body);
    }

    public putRoutineExercise(body : RoutineExercise) {
        return this.http.put<RoutineExercise>(`${this.accessPointUrl}`, body);
    }
}
