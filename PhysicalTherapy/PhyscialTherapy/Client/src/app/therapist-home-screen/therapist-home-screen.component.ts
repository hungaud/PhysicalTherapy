import { Component, OnInit } from '@angular/core';
import { Patient } from '../patient';
import { PatientService } from '../patient.service';
import { MessageService } from '../message.service';

@Component({
  selector: 'app-therapist-home-screen',
  templateUrl: './therapist-home-screen.component.html',
  styleUrls: ['./therapist-home-screen.component.scss']
})
export class TherapistHomeScreenComponent implements OnInit {
  feedback : Patient[];
  late : Patient[];
  
  constructor(private patientService: PatientService, private messageService : MessageService) { }

  ngOnInit() {
    this.messageService.add("Initiating Therapist Home Screen");
    // this.feedback = null;//this.patientService.getFeedback();
    // this.late = null;//this.patientService.getLate();
  }

}
