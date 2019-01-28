
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { RoutineService } from '../services/routine.service';
import { Patient } from '../models/Patient';
import { Routine } from '../models/Routine';
import { PatientService } from '../services/patient.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-patient-home-screen',
  templateUrl: './patient-home-screen.component.html',
  styleUrls: ['./patient-home-screen.component.scss']
})
export class PatientHomeScreenComponent implements OnInit {

  public patient :  Patient;
  public routines : Routine[];
  public username : string = '';

  constructor(private route : ActivatedRoute, private patientService : PatientService, private routineService : RoutineService) {
      this.routines = [];
    console.log(this.route.snapshot.paramMap.get('username') + ' is the name');
  }

  ngOnInit() {
    this.username = this.route.snapshot.paramMap.get('username');
    this.patientService.getPatient(this.username).subscribe(res => this.patient = res);
    this.routineService.get(this.username).subscribe(routines => this.routines = routines);
  }

}
