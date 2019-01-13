import { Component, OnInit } from '@angular/core';
import { FULL_ROSTER } from '../mock-patients';
import { Patient } from '../patient';

@Component({
  selector: 'app-patient-roster',
  templateUrl: './patient-roster.component.html',
  styleUrls: ['./patient-roster.component.scss']
})
export class PatientRosterComponent implements OnInit {
  patients: Patient[];
  constructor() { }

  getPatients(): void {
    this.patients = FULL_ROSTER;
  }
  ngOnInit() {
    this.getPatients();
  }

}
