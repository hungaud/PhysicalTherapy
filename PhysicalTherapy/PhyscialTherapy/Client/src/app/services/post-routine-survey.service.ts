import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { apiEndpoint } from '../globals';
import { PostRoutineSurvey } from '../models/PostRoutineSurvey';

@Injectable({
  providedIn: 'root'
})
export class PostRoutineSurveyService {

  constructor(private http: HttpClient) { }

  public postPostRoutineSurvey(body) {
    return this.http.post<PostRoutineSurvey>(apiEndpoint + '/postroutinesurveys' , body);
  }
}
