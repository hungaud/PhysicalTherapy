import { Component, OnInit } from '@angular/core';
import { Patient } from '../models/Patient';
import { PatientService } from '../services/patient.service';

@Component({
  selector: 'app-therapist-home-screen',
  templateUrl: './therapist-home-screen.component.html',
  styleUrls: ['./therapist-home-screen.component.scss']
})
export class TherapistHomeScreenComponent implements OnInit {
  feedback : Patient[];
  late : Patient[];
  constructor(private patientService: PatientService) { }

  ngOnInit() {
    // this.feedback = this.patientService.getFeedback();
    // this.late = this.patientService.getLate();
  }

}
