import { Component, OnInit } from '@angular/core';
import { ExerciseService } from '../services/exercise.service';
import { Exercise } from '../models/Exercise';
import { FormControl, FormGroup, FormArray, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-therapist-routine-creation-screen',
  templateUrl: './therapist-routine-creation-screen.component.html',
  styleUrls: ['./therapist-routine-creation-screen.component.scss']
})
export class TherapistRoutineCreationScreenComponent implements OnInit {

  constructor(private exerciseService : ExerciseService, private formBuilder : FormBuilder) {}
  allExercises : Exercise[] = [];
  overallForm : FormGroup;
  routineArray : FormArray;

  ngOnInit() {
    this.overallForm = this.formBuilder.group({
      routineArray : this.formBuilder.array([this.newExerciseTemplate()])});
      this.routineArray = this.overallForm.get('routineArray') as FormArray;
  }

  addExerciseTemplate() : void {
    this.routineArray.push(this.newExerciseTemplate());
    console.log("New length: " + this.routineArray.controls.length);
  }

  newExerciseTemplate() : FormGroup {
    return this.formBuilder.group({
      exerciseName: ['']
    });
  }

  deleteExercise(index : number) : void {
    this.routineArray.removeAt(index);
  }

  shiftTowardsStart(index : number) : void {
    if( index - 1 >= 0) {
      console.log("Valid shift up.");
      this.swapControlsAt(index, index - 1);
    } else {
      console.log("Invalid move up.");
    }
  }

  shiftTowardsEnd(index : number) : void {
    if( index + 1 < this.routineArray.length) {
      console.log("Valid shift down.");
      this.swapControlsAt(index, index + 1);
    } else {
      console.log("Invalid move down.");
    }
  }

  swapControlsAt(one : number, two : number) {
    let form = this.routineArray.at(one);
    this.routineArray.setControl(one, this.routineArray.at(two))
    this.routineArray.setControl(two, form);
  }

  onSubmit() : void {
    console.log(this.routineArray.value);
  }

}
