import { apiEndpoint } from '../globals'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Patient } from '../models/Patient';
import { Observable, observable } from 'rxjs';
import { map } from 'rxjs/operators';


@Injectable()
export class PatientService {
  private headers: HttpHeaders;
  private accessPointUrl: string = `${apiEndpoint}/Patients`;

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }

    // //TODO message service?

    // getFeedback(): Patient[] {
    //   //TODO actually retrieve patients with feedback
    //   return FEEDBACK;
    // }
  
    // getLate(): Patient[] {
    //   //TODO actually retrieve late patients
    //   return LATE;
    // }
  
    // getAllPatients(): Patient[] {
    //   //TODO Actually retrieve patients
    //   return ALL_PATIENTS;
    // }

    public getPatient(username : string) : Observable<Patient> {
      console.log("Entering getAllPatients in the server. " + username );
       return this.http.get<Patient>(this.accessPointUrl + "/" + username);
    }
}
