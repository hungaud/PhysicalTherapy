import { Injectable } from '@angular/core';
import { Patient } from './patient';
import { FEEDBACK, LATE, ALL_PATIENTS } from './mock-patients';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

    //TODO message service?
    constructor() { }

    getFeedback(): Patient[] {
      //TODO actually retrieve patients with feedback
      return FEEDBACK;
    }
  
    getLate(): Patient[] {
      //TODO actually retrieve late patients
      return LATE;
    }
  
    getAllPatients(): Patient[] {
      //TODO Actually retrieve patients
      return ALL_PATIENTS;
    }
}
