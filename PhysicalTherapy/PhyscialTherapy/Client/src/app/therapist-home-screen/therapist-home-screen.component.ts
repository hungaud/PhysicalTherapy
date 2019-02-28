import { Component, OnInit } from '@angular/core';
import { PatientService } from '../services/patient.service';
import { MessageService } from '../services/message.service';
import { RoutineService } from '../services/routine.service';
import { Routine } from '../models/Routine';
import { TherapistService } from '../services/therapist.service';

@Component({
  selector: 'app-therapist-home-screen',
  templateUrl: './therapist-home-screen.component.html',
  styleUrls: ['./therapist-home-screen.component.scss']
})
export class TherapistHomeScreenComponent implements OnInit {
  feedback : Routine[] = [];
  late : Routine[] = [];
  public _feedbackListfilter : string ='';
  public filteredFeedback : Routine[] = [];
  public feedbackSize : number = 0;
  public _lateListfilter : string ='';
  public filteredLate : Routine[] = [];
  public lateSize : number = 0;
  page = 1;
  pageSize = 4;
  
  constructor(private patientService: PatientService, private routineService: RoutineService,
    private messageService : MessageService, private therapistService: TherapistService) {
    this.feedback = [];
    this.late = [];
    this.filteredFeedback = [];
    this.filteredLate = [];
    this.feedbackSize = this.filteredFeedback.length;
    this.lateSize = this.filteredLate.length;
  }

  ngOnInit() {
    const user = JSON.parse(sessionStorage.getItem('user'));
    this.messageService.add("Initiating Therapist Home Screen");
    this.getFeedback(user.id);
    this.getLatePatients(user.id);
    this.lateSize = this.filteredLate.length;
    this.feedbackSize = this.filteredFeedback.length;
  }

  getFeedback(therapistId : number) : void {
    this.routineService.getRecentRoutineCompletionsByTherapistId(therapistId)
      .subscribe(feedback => {
        this.feedback = feedback;
        this.filteredFeedback = feedback;
      });
  }

  getLatePatients(therapistId : number) : void {
    this.routineService.getLateRoutinesByTherapistId(therapistId)
      .subscribe(late => {
        this.late = late;
        this.filteredLate = late;
      });
  }

  get feedbackListFilter() : string {
    return this._feedbackListfilter;
  }

  set feedbackListFilter(value) {
    this._feedbackListfilter = value;
    this.feedbackSize = this.filteredFeedback.length;
    this.filteredFeedback = this._feedbackListfilter ? this.performFeedbackFilter(this._feedbackListfilter) : this.feedback;
  }

  performFeedbackFilter(filterBy) : Routine[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.feedback.filter((feed) =>
      feed.name.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
      feed.routineId.toString().indexOf(filterBy) !== -1
    );
  }

  get filteredfeedback() : Routine[] {
    this.feedbackSize = this.filteredFeedback.length;
    return this.filteredFeedback
      .map((r, i) => ({id: i + 1, ...r}))
      //.slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
  }

  get lateListFilter() : string {
    return this._lateListfilter;
  }

  set lateListFilter(value) {
    this._lateListfilter = value;
    this.lateSize = this.filteredLate.length;
    this.filteredLate = this._lateListfilter ? this.performLateFilter(this._lateListfilter) : this.late;
  }

  performLateFilter(filterBy) : Routine[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.late.filter((l) =>
      l.name.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
      l.routineId.toString().indexOf(filterBy) !== -1
    );
  }

  get filteredlate() : Routine[] {
    this.lateSize = this.filteredLate.length;
    return this.filteredLate
      .map((r, i) => ({id: i + 1, ...r}))
      //.slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
  }

}
