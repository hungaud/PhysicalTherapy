import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpXhrBackend } from '@angular/common/http';

import { PatientService } from '../patient.service';
import { Patient } from '../patient';
import { therapistId, therapistId2, apiEndpoint } from '../globals';

@Component({
    selector: 'add-patient',
    templateUrl: './add-patient.component.html',
    styleUrls: ['./add-patient.component.scss']
})
export class AddPatientComponent {
    thePatients : Patient[] = [];

    constructor(private patientService: PatientService) { }

    search(searchValue) {
        // console.log(JSON.stringify(this.thePatients));
        const names = searchValue.value.split(' ');
        const matches = this.thePatients.filter((patient) => {
            if (names.length === 1) {
                return patient.firstName === names[0];
            } else {
                return patient.firstName === names[0]
                    && patient.lastName === names[1];
            }
        });

        // matches.forEach((match) => console.log(JSON.stringify(match)));
        this.displayMatches(matches);
    }

    displayMatches(matches) {
        const div = document.getElementById('patients');
        div.innerHTML = '';
        let button = document.createElement('button');
        const buttonText = document.createTextNode('ADD');
        button.appendChild(buttonText);
        matches.forEach((match) => {
            button.onclick = this.addPatient;
            button.id = match.patientId;
            div.innerHTML += `FIRST NAME: ${match.firstName} 
            LAST NAME: ${match.lastName} ID: ${match.patientId} 
            BIO: ${match.bio} `;
            div.appendChild(button);
        });
    }

    addPatient(id) {
        console.log(JSON.stringify(id.target.id));
        this.patientService.getPatientById(id.target.id)
            .subscribe((result) => {
                console.log(JSON.stringify(result));
            });
        //body.therapistId = therapistId;
        //this.patientService.putPatient(id.target.id, body);
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
