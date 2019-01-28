import { Injectable } from '@angular/core';
import { Patient } from '../models/patient';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { apiEndpoint } from '../globals';

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


    public getPatient(username: string): Observable<Patient> {
      console.log("Entering getAllPatients in the server. " + username);
      return this.http.get<Patient>(apiEndpoint + "/Patients/" + username);
    }
  
    getAllPatients(): Observable<Patient[]> {
      console.log("Entering getAllPatients in the server.");
      return this.http.get<Patient[]>(apiEndpoint + '/patients');     
    }

    getPatientsByTherapistId(therapistId : number): Observable<Patient[]> {
      console.log("Entering getPatientsByTherapistId in the server.");
      return this.http.get<Patient[]>(apiEndpoint + '/patients/tid/' + therapistId);     
    }
}
