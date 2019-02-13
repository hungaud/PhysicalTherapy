import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Exercise } from '../models/Exercise';
import { apiEndpoint } from '../globals';

@Injectable({
  providedIn: 'root'
})
export class ExerciseService {
  //private accessPointUrl: string = `${apiEndpoint}/Exercises`;


  constructor(private http : HttpClient) { }

  getAllExercises() : Observable<Exercise[]> {
    return this.http.get<Exercise[]>(apiEndpoint + '/exercises');
  }

  public postExercise(body) {
    return this.http.post<Exercise>(apiEndpoint + '/exercises' , body);
  }

}
