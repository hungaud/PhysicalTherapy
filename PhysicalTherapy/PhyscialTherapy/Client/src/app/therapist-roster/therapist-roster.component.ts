import { Component, OnInit, SystemJsNgModuleLoader, ElementRef } from '@angular/core';
import { PatientService } from '../patient.service';
import { Patient } from '../patient';
import { MessageService } from '../message.service';

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
    this.messageService.add("Initiating Roster");
    this.setRoster();
    console.log("Finishing setRoster ngOnInit");
    this.messageService.add("Roster has been set!");
  }

  setRoster() : void {
    this.messageService.add("Inside setRoster");
    console.log("Calling set roster")
    this.patientService.getAllPatients().subscribe(allPatients => this.allPatients = allPatients);
    console.log("Finishing setRoster")
    this.messageService.add("Finished subscribing to the service");
  }

}
