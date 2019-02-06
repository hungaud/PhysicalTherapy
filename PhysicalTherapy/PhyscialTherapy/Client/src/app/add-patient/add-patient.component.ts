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

    addPatient() {
        this.filteredPatients.forEach((patient) => {
            console.log(patient.patientId);
            const row = (<HTMLInputElement>document.getElementById(patient.patientId.toString()));
            if (row && row.checked) {
                this.patientService.getPatientById(patient.patientId)
                    .subscribe((result) => {
                        result.therapistId = therapistId;
                        this.patientService.putPatient(patient.patientId, result).subscribe();
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
