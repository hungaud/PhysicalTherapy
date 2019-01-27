import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { RoutineService } from '../services/routine.service';
import { Patient } from '../models/Patient';
import { Routine } from '../models/Routine';
import { PatientService } from '../services/patient.service';

@Component({
  selector: 'app-patient-home-screen',
  templateUrl: './patient-home-screen.component.html',
  styleUrls: ['./patient-home-screen.component.scss']
})
export class PatientHomeScreenComponent implements OnInit {

  public patient : Patient;
  public routines : Routine[] = [];

  constructor(private patientService : PatientService, private routineService : RoutineService) {
    this.routines = [];
  }


  ngOnInit() {
    //this.patientService.getPatient('hung').subscribe(patient => this.patient = patient)
    this.routineService.getAll().subscribe(routines => this.routines = routines)

  }

}
