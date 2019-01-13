import { Component, OnInit } from '@angular/core';
import { LATE_PATIENTS, PATIENTS } from '../mock-patients';
import { Patient } from '../patient';

@Component({
  selector: 'app-home-view',
  templateUrl: './home-view.component.html',
  styleUrls: ['./home-view.component.scss']
})
export class HomeViewComponent implements OnInit {
  latePatients: Patient[];
  feedbackPatients: Patient[];

  constructor() { }

  setPatients(): void {
    this.latePatients = LATE_PATIENTS;
    this.feedbackPatients = PATIENTS;
  }

  ngOnInit() {
    this.setPatients();
  }

}
