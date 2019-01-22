import { Injectable } from '@angular/core';
import { Patient } from './patient';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

    //TODO message service?
    constructor(private http: HttpClient) { }

    // getFeedback(): Patient[] {
    //   //TODO actually retrieve patients with feedback
    //   return FEEDBACK;
    // }
  
    // getLate(): Patient[] {
    //   //TODO actually retrieve late patients
    //   return LATE;
    // }
  
    // getAllPatients(): Observable<Patient[]> {
    //   return this.http.get<Patient[]>('https://localhost:44379/api/patients');
    // }
}
