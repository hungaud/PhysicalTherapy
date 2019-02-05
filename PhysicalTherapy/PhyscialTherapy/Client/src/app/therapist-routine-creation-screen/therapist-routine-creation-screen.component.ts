import { Component, OnInit } from '@angular/core';
import { ExerciseService } from '../services/exercise.service';
import { Exercise } from '../models/Exercise';
import { FormControl, FormGroup, FormArray, FormBuilder, AbstractControl } from '@angular/forms';
import { isUndefined } from 'util';

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
      targetIndex: [],
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

  triggerReorder() : void {
    //First block confirms that all exercises are ranked
    let dummy = [''];
    //fill in empty targetIndexes
    for(var i = 0; i < this.routineArray.length; i++) {
      let currentControl = this.routineArray.at(i);
      if( (currentControl.get('targetIndex').value as unknown as number) == null ) {
        currentControl.get('targetIndex').setValue(i + 1);
      }
    }

    //This block performs a selection sort and an in-place swap.
    for(var i = 0; i < this.routineArray.length; i++) {
      console.log("Entered first loop :" + i);
      let startControl = this.routineArray.at(i);
      let lowestIndex = i;
      for(var j = i + 1; j < this.routineArray.length; j++) {
        console.log("Entered second loop :" + j);
        let currentControl = this.routineArray.at(j);
        let currentLowestControl = this.routineArray.at(lowestIndex);
        if(currentControl.get('targetIndex').value < currentLowestControl.get('targetIndex').value) {
          console.log("Entered if");
          lowestIndex = j;
        }
        console.log("Leaving inner loop");
      }
      console.log("Starting swap : ");
      console.log(this.routineArray.value);
      //Three-way swap
      let temp = startControl;
      this.routineArray.setControl(i, this.routineArray.at(lowestIndex));
      this.routineArray.setControl(lowestIndex, temp);

      console.log("Ending swap : ");
      console.log(this.routineArray.value);
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
