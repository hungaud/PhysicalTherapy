import { Component, OnInit } from '@angular/core';
import { ExerciseService } from '../services/exercise.service';
import { Exercise } from '../models/Exercise';
import { FormControl, FormGroup, FormArray, FormBuilder, AbstractControl, Validators } from '@angular/forms';
import { isUndefined } from 'util';
import { Patient } from '../models/patient';
import { PatientService } from '../services/patient.service';
import { RoutineExerciseService } from '../services/routineExercise.service';
import { RoutineService } from '../services/routine.service';
import { element } from '@angular/core/src/render3';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-therapist-routine-creation-screen',
  templateUrl: './therapist-routine-creation-screen.component.html',
  styleUrls: ['./therapist-routine-creation-screen.component.scss']
})
export class TherapistRoutineCreationScreenComponent implements OnInit {

  constructor(private exerciseService : ExerciseService, private formBuilder : FormBuilder,
    private patientService : PatientService, private routineExerciseService : RoutineExerciseService,
    private routineService : RoutineService, private http : HttpClient) {}
    
  allExercises : Exercise[] = [];
  overallForm : FormGroup;
  routineArray : FormArray;
  therapistsPatients : Patient[] = [];
  files : File[] = []

  ngOnInit() {
    const therapist = JSON.parse(sessionStorage.getItem('user'));
    this.overallForm = this.formBuilder.group({
      routineArray : this.formBuilder.array([this.newExerciseTemplate()])
    });
      this.routineArray = this.overallForm.get('routineArray') as FormArray;
    this.patientService.getPatientsByTherapistId(therapist.id)
      .subscribe((result) => {
        this.therapistsPatients = result;
      });
    this.exerciseService.getAllExercises()
      .subscribe((result) =>  {
        this.allExercises = result;
      });
  }

  addExerciseTemplate() : void {
    this.routineArray.push(this.newExerciseTemplate());
  }

  newExerciseTemplate() : FormGroup {
    return this.formBuilder.group({
      targetIndex: [],
      exerciseName: ['', Validators.required],
      holdLength: ['', Validators.min(0)],
      reps: ['', Validators.min(0)],
      sets: ['',[Validators.min(1), Validators.required]],
      note: [''],
      file: ['']
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
    for(let i = 0; i < this.routineArray.length; i++) {
      let currentControl = this.routineArray.at(i);
      if( (currentControl.get('targetIndex').value as unknown as number) == null ) {
        currentControl.get('targetIndex').setValue(i + 1);
      }
    }

    //This block performs a selection sort and an in-place swap.
    for(let i = 0; i < this.routineArray.length; i++) {
      let startControl = this.routineArray.at(i);
      let lowestIndex = i;
      for(let j = i + 1; j < this.routineArray.length; j++) {
        let currentControl = this.routineArray.at(j);
        let currentLowestControl = this.routineArray.at(lowestIndex);
        if(currentControl.get('targetIndex').value < currentLowestControl.get('targetIndex').value) {
          lowestIndex = j;
        }

      }
      //Three-way swap
      let temp = startControl;
      this.routineArray.setControl(i, this.routineArray.at(lowestIndex));
      this.routineArray.setControl(lowestIndex, temp);
    }
    //TODO another block that resets the numbers to their indexes?
  }

  swapControlsAt(one : number, two : number) {
    let form = this.routineArray.at(one);
    this.routineArray.setControl(one, this.routineArray.at(two))
    this.routineArray.setControl(two, form);
  }

  onSubmit() : void {
    const patient = (<HTMLInputElement>document.getElementById('nameSelect')).value;
    if(!this.overallForm.invalid && patient) {
      const routine = this.setRoutine(patient);
      this.routineService.postRoutine(routine)
        .subscribe((result) => {
          this.handleExercises(result);
          this.handleFiles(result.routineId);
          this.clearArray();
        });
    } else {
      console.log("Form is invalid: no submission accepted.");
    }
  }

  setRoutine(patient) {
    return {
      Description: 'The new routine',
      Date: new Date(),
      IsComplete: false,
      IsNew: true,
      Name: 'New Routine',
      PatientId: patient.replace(/\s/g, '').split(':')[1].charAt(0)
    }
  }

  handleExercises(result) {
    const routineExerId = result.routineId;
    this.routineArray.value.forEach((exer, index) => {
      const exerciseName = exer.exerciseName;
      const exId = this.allExercises.find((element => element.name === exerciseName));
      const holdLen = exer.holdLength;
      const notes = exer.note;
      const reps = exer.reps;
      const sets = exer.sets;
      const exercise = {
        exerciseId: exId.exerciseId,
        frequencyPerDay: 1,
        holdLength: holdLen,
        notes: notes,
        rep: reps,
        routineId: routineExerId,
        sets: sets
      };
      this.routineExerciseService.postRoutineExercise(exercise).subscribe();
    });
  }

  handleFiles(routineId) {
    this.files.forEach((file) => {
      this.uploadFile(file, routineId);
    });
    this.files = [];
  }

  uploadFile(file, routineId) {
    const fd = new FormData();
    fd.append('uploadFile', file, file.name);
    // We will need to have the upload URL location here
    this.http.post(`https://capstone-pt.azurewebsites.net`, fd)
      .subscribe((response) => {
        console.log(response);
      });
  }

  clearArray() {
    this.routineArray.value.forEach((value, index) => {
      if (index !== 0) {
        this.routineArray.removeAt(1);
      }
    });
    this.routineArray.reset();
  }

  onFileSelected(event) {
    for (let i = 0; i < event.target.files.length; i++) {
      this.files.push(event.target.files[i]);
    }
  }

}
