import { Injectable } from '@angular/core';
import { Patient } from './patient';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

    //TODO message service?
    constructor(private http: HttpClient, private messageService : MessageService) { }

    getFeedback(): Patient[] {
      //TODO actually retrieve patients with feedback
      return null;
    }
  
    getLate(): Patient[] {
      //TODO actually retrieve late patients
      return null;
    }
  
    getAllPatients(): Observable<Patient[]> {
      this.messageService.add('Retrieving all patients');
      return this.http.get<Patient[]>('https://localhost:44379/api/patients');
    }
}
