import { Component, OnInit, SystemJsNgModuleLoader, ElementRef } from '@angular/core';
import { PatientService } from '../patient.service';
import { Patient } from '../patient';
import { MessageService } from '../message.service';
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
    this.setRosterByTherapistId(therapistId);
    console.log("Finishing setRoster ngOnInit");
  }

  setRosterByTherapistId(therapistId: number) : void {
    this.patientService.getPatientsByTherapistId(therapistId)
      .subscribe(allPatients => this.allPatients = allPatients)
  }


}
