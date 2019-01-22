import { Component, OnInit, SystemJsNgModuleLoader, ElementRef } from '@angular/core';
import { PatientService } from '../patient.service';
import { Patient } from '../patient';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-therapist-roster',
  templateUrl: './therapist-roster.component.html',
  styleUrls: ['./therapist-roster.component.scss']
})
export class TherapistRosterComponent implements OnInit {
  allPatients : Patient[];
  testPatient: Patient;
  

  constructor(private patientService: PatientService, private http: HttpClient) { }

  ngOnInit() {
    //this.setRoster;
  }

  setRoster() : void {
    //testHeader.innerText = "Take that";
    this.http.get<Patient[]>('https://localhost:44379/api/patients')
    .subscribe((response) => {
        if(response['0'] != null) {
          this.testPatient = response['0'];
          //testHeader.innerText = "Made it to the end!";
          
        } else {
          //testHeader.innerText = "Didn't find anything in the JSON";
        }
    })
    
  }

}
