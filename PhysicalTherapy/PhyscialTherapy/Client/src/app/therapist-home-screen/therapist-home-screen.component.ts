import { Component, OnInit } from '@angular/core';
import { Patient } from '../models/patient';
import { PatientService } from '../services/patient.service';
import { MessageService } from '../services/message.service';
import { RoutineService } from '../services/routine.service';
import { Routine } from '../models/Routine';
import { therapistId } from '../globals';

@Component({
  selector: 'app-therapist-home-screen',
  templateUrl: './therapist-home-screen.component.html',
  styleUrls: ['./therapist-home-screen.component.scss']
})
export class TherapistHomeScreenComponent implements OnInit {
  feedback : Routine[] = [];
  late : Routine[] = [];
  
  constructor(private patientService: PatientService, private routineService: RoutineService, private messageService : MessageService) { }

  ngOnInit() {
    this.messageService.add("Initiating Therapist Home Screen");
    this.getFeedback(therapistId);
    this.getLatePatients(therapistId);
  }

  getFeedback(therapistId : number) : void {
    this.routineService.getRecentRoutineCompletionsByTherapistId(therapistId).subscribe(feedback => this.feedback = feedback);
  }

  getLatePatients(therapistId : number) : void {
    this.routineService.getLateRoutinesByTherapistId(therapistId).subscribe(late => this.late = late);
  }

}
