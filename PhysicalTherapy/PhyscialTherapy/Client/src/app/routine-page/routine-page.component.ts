import { Component, OnInit } from '@angular/core';
import { RoutineService } from '../services/routine.service';
import { ActivatedRoute } from '@angular/router';
import { Routine } from '../models/routine';
import { RoutineExercise } from '../models/routineExercise';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { isNullOrUndefined } from 'util';

@Component({
  selector: 'app-routine-page',
  templateUrl: './routine-page.component.html',
  styleUrls: ['./routine-page.component.scss']
})

export class RoutinePageComponent implements OnInit {

  constructor(private route : ActivatedRoute,
    private routineService : RoutineService,
    private formBuilder : FormBuilder) { }

  public routineId : number = 1012;
  public exerciseList : RoutineExercise[];
  public overallForm : FormGroup;
  public routineArray : FormArray;

  ngOnInit() {
    const user = JSON.parse(sessionStorage.getItem('user'));
    this.overallForm = this.formBuilder.group({
      routineName : [''],
      routineArray : this.formBuilder.array([])});
    this.routineArray = this.overallForm.get('routineArray') as FormArray;

    //Gettingt the routine from the server
    this.routineService.getSingleRoutineByRoutineId(this.routineId)
    .subscribe(routine => {
      this.exerciseList = this.getExerciseList(routine);
      this.buildOverallForm();
    });
  }

  private getExerciseList(routine : Routine[]) : RoutineExercise[] {
    let list = routine[0].routineExercises;
    return list;
  }

  private newExerciseTemplate() : FormGroup {
    return this.formBuilder.group({
      //From Exercise
      exerciseName: [''],
      //From RoutineExercise
      holdLength: [],
      reps: [],
      sets : this.formBuilder.array([]),
      note: ['']
    });
  }

  private buildOverallForm() {
    let routineArray = this.overallForm.get('routineArray') as FormArray;
    this.exerciseList.forEach(routineExercise => {
      routineArray.push(this.exerciseTemplateFromRoutineExercise(routineExercise));
    });
    console.log(routineArray.controls[0] + ", " + routineArray);
  }

  private exerciseTemplateFromRoutineExercise(exercise : RoutineExercise) : FormGroup {
    let ret = this.newExerciseTemplate();
    ret.get('exerciseName').setValue(exercise.exercise.name);

    let setArray = ret.get('sets') as FormArray;
    //Check to see if it is a hold or a rep exercise
    if(!isNullOrUndefined(exercise.rep) && exercise.rep > 0) {
      for(let i = 0; i < exercise.sets; i++) {
        setArray.push(this.formBuilder.group({
          value : [exercise.rep]
        }));
      }
    } else if (!isNullOrUndefined(exercise.holdLength) && exercise.holdLength > 0) {
       for(let i = 0; i < exercise.sets; i++) {
         setArray.push(this.formBuilder.group({
           value: [exercise.holdLength]
         }));
        }
    }
    return ret;
  }
}
