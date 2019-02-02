
import { Component, OnInit, PipeTransform, Pipe } from '@angular/core';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { RoutineService } from '../services/routine.service';
import { Patient } from '../models/Patient';
import { Routine } from '../models/Routine';
import { PatientService } from '../services/patient.service';
import { DecimalPipe } from '@angular/common';


@Component({
  selector: 'app-patient-home-screen',
  templateUrl: './patient-home-screen.component.html',
  styleUrls: ['./patient-home-screen.component.scss']
})

export class PatientHomeScreenComponent implements OnInit {

  public patient :  Patient;
  public routines : Routine[];
  public filteredRoutines : Routine[];
  public username : string = '';
  public _listfilter ='';
  page = 1;
  pageSize = 4;
  public collectionSize : number = 0;

  constructor(private route : ActivatedRoute, private patientService : PatientService, private routineService : RoutineService) {
    this.routines = [];
    this. filteredRoutines = [];
    this.collectionSize = this.filteredRoutines.length;
  }

  ngOnInit() {
    this.username = this.route.snapshot.paramMap.get('username');
    this.patientService.getPatient(this.username).subscribe(res => this.patient = res);
    this.routineService.get(this.username).subscribe(res =>  {this.routines = res, this.filteredRoutines = this.routines });
    this.collectionSize = this.filteredRoutines.length;
  }

  get listFilter() : string {
    return this._listfilter;
    this.collectionSize = this.filteredRoutines.length;
  }

  set listFilter(value: string) {
    this._listfilter = value;
    this.collectionSize = this.filteredRoutines.length;
    this.filteredRoutines = this._listfilter ? this.performFilter(this.listFilter) : this.routines;
  }

  performFilter(filterBy: string): Routine[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.routines.filter((routine: Routine) =>
      routine.name.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
      routine.routineId.toString().indexOf(filterBy) !== -1);
  }

  // copied from https://ng-bootstrap.github.io/#/components/table/examples#pagination 
  get filteredroutines(): Routine[] {
    this.collectionSize = this.filteredRoutines.length;
    return this.filteredRoutines
      .map((r, i) => ({id: i + 1, ...r}))
      .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
  }
}
