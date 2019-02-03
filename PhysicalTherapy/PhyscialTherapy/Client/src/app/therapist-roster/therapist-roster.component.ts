import { Component, OnInit, SystemJsNgModuleLoader, ElementRef } from '@angular/core';
import { PatientService } from '../services/patient.service';
import { Patient } from '../models/patient';
import { MessageService } from '../services/message.service';
import { therapistId } from '../globals';

@Component({
  selector: 'app-therapist-roster',
  templateUrl: './therapist-roster.component.html',
  styleUrls: ['./therapist-roster.component.scss']
})
export class TherapistRosterComponent implements OnInit {
  allPatients : Patient[] = [];

  constructor(private patientService: PatientService, private messageService : MessageService ) { }

  ngOnInit() {
    this.allPatients = [];
    const user = JSON.parse(sessionStorage.getItem('user'));
    this.setRosterByTherapistId(user.id);
    console.log("Finishing setRoster ngOnInit");
  }

  setRosterByTherapistId(therapistId: number) : void {
    this.patientService.getPatientsByTherapistId(therapistId)
      .subscribe(allPatients => this.allPatients = allPatients)
  }


}
