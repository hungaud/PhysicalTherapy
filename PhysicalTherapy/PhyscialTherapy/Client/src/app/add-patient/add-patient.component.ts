import { Component, OnInit } from '@angular/core';

import { PatientService } from '../patient.service';
import { Patient } from '../patient';

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
