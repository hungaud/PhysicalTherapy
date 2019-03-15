import { Component, OnInit, SystemJsNgModuleLoader, ElementRef } from '@angular/core';
import { PatientService } from '../services/patient.service';
import { Patient } from '../models/patient';
import { MessageService } from '../services/message.service';

@Component({
  selector: 'app-therapist-roster',
  templateUrl: './therapist-roster.component.html',
  styleUrls: ['./therapist-roster.component.scss']
})
export class TherapistRosterComponent implements OnInit {
  allPatients : Patient[] = [];
  public _patientFilter : string = '';
  public filteredPatients : Patient[] = [];
  public patientSize : number =0;
  page = 1;
  pageSize = 4;

  constructor(private patientService: PatientService,
    private messageService : MessageService) {
    this.allPatients = [];
    this.filteredPatients = [];
    this.patientSize = this.filteredPatients.length;
  }

  ngOnInit() {
    this.allPatients = [];
    const user = JSON.parse(sessionStorage.getItem('user'));
    this.setRosterByTherapistId(user.id);
    this.patientSize = this.filteredPatients.length;
    console.log("Finishing setRoster ngOnInit");
  }

  setRosterByTherapistId(therapistId: number) : void {
    this.patientService.getPatientsByTherapistId(therapistId)
      .subscribe(allPatients => {
        this.allPatients = allPatients;
        this.filteredPatients = allPatients;
      });
  }

  get patientsListFilter() : string {
    return this._patientFilter;
  }

  set patientsListFilter(value) {
    this._patientFilter = value;
    this.patientSize = this.filteredPatients.length;
    this.filteredPatients = this._patientFilter ? this.performPatientFilter(this._patientFilter) : this.allPatients;
  }

  performPatientFilter(filterBy) : Patient[] {
    filterBy = filterBy.toLocaleLowerCase();
    if (!isNaN(filterBy)) {
      return this.allPatients.filter((pat) =>
        pat.patientId.toString().indexOf(filterBy) !== -1
      );
    } else {
      const name = filterBy.split(' ');
      return this.allPatients.filter((pat) =>
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
