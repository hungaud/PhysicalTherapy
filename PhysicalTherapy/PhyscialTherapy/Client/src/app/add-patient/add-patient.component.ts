import { Component, OnInit } from '@angular/core';

import { PatientService } from '../services/patient.service';
import { Patient } from '../models/patient';
import { therapistId, therapistId2 } from '../globals';

@Component({
    selector: 'add-patient',
    templateUrl: './add-patient.component.html',
    styleUrls: ['./add-patient.component.scss']
})
export class AddPatientComponent implements OnInit {
    thePatients : Patient[] = [];
    patientList : number[] = [];

    constructor(private patientService: PatientService) { }

    search(searchValue) {
        this.patientList = [];
        const names = searchValue.value.split(' ');
        const matches = this.thePatients.filter((patient) => {
            if (names.length === 1) {
                return patient.firstName === names[0];
            } else {
                return patient.firstName === names[0]
                    && patient.lastName === names[1];
            }
        });
        matches.forEach((match) => {
            this.patientList.push(match.patientId);
        });
        this.displayMatches(matches);
    }

    displayMatches(matches) {
        const div = document.getElementById('patients');
        div.innerHTML = '';
        matches.forEach((match) => {
            div.innerHTML += `FIRST NAME: ${match.firstName} 
            LAST NAME: ${match.lastName} ID: ${match.patientId} 
            BIO: ${match.bio} <input type="checkbox" id="${match.patientId}"><br>`;
        });
    }

    addPatient() {
        this.patientList.forEach((patient) => {
            const checked = (<HTMLInputElement>document.getElementById(patient.toString())).checked;
            if (checked) {
                this.patientService.getPatientById(patient)
                    .subscribe((result) => {
                        result.therapistId = therapistId;
                        this.patientService.putPatient(patient, result).subscribe();
                    });
            }
        });
    }

    ngOnInit() {
        this.patientService.getAllPatients()
            .subscribe((result) => {
                result.forEach((patient) => {
                    this.thePatients.push(patient);
                });
            });
    }
}
