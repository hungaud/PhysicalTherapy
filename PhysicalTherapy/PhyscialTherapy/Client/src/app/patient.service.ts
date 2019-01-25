import { Injectable } from '@angular/core';
import { Patient } from './patient';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

    //TODO message service?
    constructor(private http: HttpClient) { }

    getFeedback(): Patient[] {
      //TODO actually retrieve patients with feedback
      return null;
    }
  
    getLate(): Patient[] {
      //TODO actually retrieve late patients
      return null;
    }
  
    getAllPatients(): Observable<Patient[]> {
      console.log("Entering getAllPatients in the server.");
      return this.http.get<Patient[]>('https://localhost:44379/api/patients');;      
    }
}
