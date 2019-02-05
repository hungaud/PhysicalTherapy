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
    public _patientListFilter : string = '';
    public filteredPatients : Patient[] = [];
    public patientSize : number = 0;
    page = 1;
    pageSize = 4;

    constructor(private patientService: PatientService) { }

    /* search(searchValue) {
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
    } */

    addPatient() {
        this.patientList.forEach((patient) => {
            const checked = (<HTMLInputElement>document.getElementById(patient.toString())).checked;
            if (checked) {
                console.log('OOOO IT CHECKED');
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
                    this.filteredPatients = this.thePatients;
                });
            });
    }

    get patientListFilter() : string {
        return this._patientListFilter;
    }

    set patientListFilter(value) {
        this._patientListFilter = value;
        this.patientSize = this.filteredPatients.length;
        this.filteredPatients = this.patientListFilter ? this.performPatientFilter(this._patientListFilter) : this.thePatients;
    }

    performPatientFilter(filterBy) : Patient[] {
        filterBy = filterBy.toLocaleLowerCase();
        if (!isNaN(filterBy)) {
            return this.thePatients.filter((pat) =>
                pat.patientId.toString().indexOf(filterBy) !== -1
            );
        } else {
            const name = filterBy.split(' ');
            return this.thePatients.filter((pat) =>
                pat.firstName.toLocaleLowerCase() === name[0] ||
                pat.lastName.toLocaleLowerCase() === name[0]
            );
        }
    }

    get filteredpatients() : Patient[] {
        this.patientSize = this.filteredPatients.length;
        return this.filteredPatients
            .map((r, i) => ({id: i + 1, ...r}))
            .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
    }
}
