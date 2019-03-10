import { Component, OnInit } from '@angular/core';
import { RoutineService } from '../services/routine.service';
import { ActivatedRoute } from '@angular/router';
import { Routine } from '../models/routine';
import { Exercise } from '../models/Exercise';
import { RoutineExercise } from '../models/routineExercise';
import { isNullOrUndefined } from 'util';
import { PostRoutineSurvey } from '../models/PostRoutineSurvey';
import { SSL_OP_SSLEAY_080_CLIENT_DH_BUG } from 'constants';
import { timer, Subscription } from 'rxjs';
import { RoutineExerciseService } from '../services/routineExercise.service';
import { ExerciseService } from '../services/exercise.service';
import { PostRoutineSurveyService } from '../services/post-routine-survey.service';


@Component({
  selector: 'app-routine-page',
  templateUrl: './routine-page.component.html',
  styleUrls: ['./routine-page.component.scss']
})

export class RoutinePageComponent implements OnInit {

  constructor(private route : ActivatedRoute,
    private routineService : RoutineService,
    private routineExerciseService : RoutineExerciseService,
    private exerciseService : ExerciseService,
    private postRoutineSurveyService : PostRoutineSurveyService) { }

  public allExercises : Exercise[] = [];
  public routineId : number;
  public exerciseList : RoutineExercise[];
  public originalRoutine : Routine;
  //This holds the number of sets with the expected reps/time
  public expectedKey : number[][];
  //This holds their actual rep count/hold time
  public actualKey : string[][];
  //Holds the type of each exercise
  public timeOrRep : number[];
  //Timer object to handle time buttons;
  public subscription : Subscription;
  public counting: boolean = false;

  /**
   * Type: 1 == 'rep'
   * Type: 2 == 'holdLength'
   * Type: 0 == NOTHING
   */


  ngOnInit() {
    const user = JSON.parse(sessionStorage.getItem('user'));
    this.routineId = JSON.parse(sessionStorage.getItem('routineRoute'));
    this.expectedKey = new Array();
    this.actualKey = new Array();
    this.timeOrRep = [];


    //Getting the routine from the server
    this.routineService.getSingleRoutineByRoutineId(this.routineId)
    .subscribe(routine => {
      this.originalRoutine = routine[0];
      this.exerciseList = this.getExerciseList(routine);
      this.createKeys();
      console.log(this.actualKey);
    });
  }

  private getExerciseList(routine : Routine[]) : RoutineExercise[] {
    let list = routine[0].routineExercises;
    return list;
  }

  private createKeys() : void {
    this.exerciseList.forEach(element => {
      let expectedTemp = [];
      let actualTemp = [];
      let type = this.findIfTimeOrReps(element);
      
      for(let i = 0; i < element.sets; i++) {
        expectedTemp.push(this.getTimeOrReps(element));
        actualTemp.push(this.getTimeOrReps(element));
      }

      this.expectedKey.push(expectedTemp);
      this.actualKey.push(actualTemp);
      this.timeOrRep.push(type);
    });
  }

  private findIfTimeOrReps(routineExercise : RoutineExercise) : number {
    let reps = routineExercise.rep;
    let time = routineExercise.holdLength;
    if(!isNullOrUndefined(reps) && reps > 0) {
      return 1;
    } else if (!isNullOrUndefined(time) && time > 0) {
      return 2;
    } else {
      return 0;
    }
  }

  private getTimeOrReps(routineExercise : RoutineExercise) : number {
    let type = this.findIfTimeOrReps(routineExercise);
    if(type == 1) {
      return routineExercise.rep;
    } else if (type == 2) {
      return routineExercise.holdLength;
    } else {
      return 0;
    }
  }

  public exerciseClick(exercise : number, set : number) : void {
    console.log("Entering Exercise Click");
    if(this.timeOrRep[exercise] == 1) {
      this.repClick(exercise, set);
    } else if (this.timeOrRep[exercise] == 2) {
      this.timeClick(exercise, set);
    } else {
      console.log("Invalid exercise type");
    }
  }

  private repClick(exercise : number, set : number) : void {
    console.log("Entering rep click");
    if(parseInt(this.actualKey[exercise][set]) == this.expectedKey[exercise][set]) {
      console.log("Entering complete!");
      this.actualKey[exercise][set] = "Complete!";
    }
    else if (this.actualKey[exercise][set] == "Complete!") {
      console.log("Entering the Reset from complete")
      this.actualKey[exercise][set] = (this.expectedKey[exercise][set] - 1).toString();
    }
    else if(parseInt(this.actualKey[exercise][set]) == 0) {
      this.actualKey[exercise][set] = this.expectedKey[exercise][set].toString();
    }
    else {
      console.log("Entering the else");
      let value = parseInt(this.actualKey[exercise][set]);
      value--;
      this.actualKey[exercise][set] = value.toString();
    }
    console.log(this.actualKey)
  }

  private timeClick(exercise : number, set : number) : void {
    if(!isNullOrUndefined(this.subscription)) {
      console.log("Wipe Timer Block");
      this.subscription.unsubscribe();
      this.subscription = null;
    }
    else if(this.actualKey[exercise][set] == 'Complete!') {
      console.log("Complete Reset block");
      this.actualKey[exercise][set] = this.expectedKey[exercise][set].toString();
    }
    else if( isNullOrUndefined(this.subscription) ) {
      console.log("No timer found block");
      let time = timer(0,1000);
      //Subscription runs the timer
      this.subscription = time.subscribe(x => {
        if(parseInt(this.actualKey[exercise][set]) == 0) {
          //This case is for a completed set
          console.log("Exercise complete!");
          this.actualKey[exercise][set] = 'Complete!';
          this.subscription.unsubscribe();
          this.subscription = null;
        }
        else {
          let value = parseInt(this.actualKey[exercise][set]);
          value--;
          this.actualKey[exercise][set] = value.toString();
        }
      });
    }
  }

  public submitRoutine() : void {
    let repostRoutine = JSON.parse(JSON.stringify(this.originalRoutine)) as Routine;
    repostRoutine.date = null;
    repostRoutine.routineId = null;
    console.log(repostRoutine);
    this.repeatRoutineEntry(this.originalRoutine);
    this.updateRoutineEntry(this.originalRoutine);
  }

  private repeatRoutineEntry(routine : Routine) {
    const routineEntry = this.freshRoutineEntry(routine);
    this.routineService.postRoutine(routineEntry)
    .subscribe((rout) => {
      this.handleFreshExercises(this.originalRoutine, rout.routineId);
    });
  }

  private updateRoutineEntry(routine : Routine) {
    const postRoutineSurvey = this.collectSurveyInfo();
    //Post the survey
    this.postRoutineSurveyService.postPostRoutineSurvey(postRoutineSurvey)
    .subscribe((prs) => {
      //Grab the survey ID, then put the routine with the survey ID
      const updatedRoutineInfo = this.finishedRoutineEntry(routine, prs.postRoutineSurveyId);
      this.routineService.putRoutine(updatedRoutineInfo).subscribe((rout) => {
        //Update CompleteReps in each RoutineExercise
        this.handleUpdatedExercises(this.originalRoutine, this.originalRoutine.routineId);
      })
    });
    //Post the survey
    //get the survey ID, then put the Routine
    //Update CompleteReps in each RoutineExercise

  }

  freshRoutineEntry(routine : Routine) {
    return {
      Description: routine.description,
      Date: new Date(),
      IsComplete: false,
      IsNew: true,
      Name: routine.name,
      PatientId: routine.patientId
    }
  }

  handleFreshExercises(routine : Routine, routineId : number) {
    const routineExerId = routineId;
    routine.routineExercises.forEach((exer) => {
      const exercise = {
        ExerciseId: exer.exercise.exerciseId,
        FrequencyPerDay: 1,
        HoldLength: exer.holdLength,
        Notes: exer.notes,
        Rep: exer.rep,
        RoutineId: routineExerId,
        Sets: exer.sets,
        CompleteReps: null
      };
      console.log("Posting fresh routineExercise");
      this.routineExerciseService.postRoutineExercise(exercise).subscribe();
    });
  }

  finishedRoutineEntry(routine : Routine, postRoutineSurveyId : number) {
    return {
      RoutineId : routine.routineId,
      Description: routine.description,
      Date: routine.date,
      IsComplete: true,
      IsNew: false,
      Name: routine.name,
      PatientId: routine.patientId,
      PostRoutineSurveyId : postRoutineSurveyId
    }
  }

  handleUpdatedExercises(routine : Routine, routineId : number) {
    const routineExerId = routineId;
    let index = 0;
    routine.routineExercises.forEach((exer) => {
      const repString = this.collectCompleteReps(index);
      const exercise = {
        exercise : null,
        exerciseId: exer.exercise.exerciseId,
        frequencyPerDay: 1,
        holdLength: exer.holdLength,
        notes: exer.notes,
        rep: exer.rep,
        routineId: routineExerId,
        routine: null,
        routineExerciseId: exer.routineExerciseId,
        sets: exer.sets,
        completeReps: repString
      };
      console.log("Updated exercise");
      this.routineExerciseService.putRoutineExercise(exercise).subscribe(re => {
        console.log(re);
      });
      index++;
    });
  }

  collectCompleteReps(setIndex : number) {
    let reps = "";
    let repIndex = 0;
    this.actualKey[setIndex].forEach((rep) => {
      if( reps != "") {
        reps = reps + ",";
      }

      if(rep == 'Complete!') {
        reps = reps + this.expectedKey[setIndex][repIndex].toString();
      } else if (rep == this.expectedKey[setIndex][repIndex].toString()) {
        reps = reps + '0';
      } else {
        reps = reps + this.actualKey[setIndex][repIndex].toString();
      }

      repIndex++;
    });

    return reps;
  }

  collectSurveyInfo() {
    let difficulty = parseInt(document.querySelector('input[name="radioDifficulty"]:checked').getAttribute("value"));
    let pain = parseInt(document.querySelector('input[name="radioPain"]:checked').getAttribute("value"));
    let tiredness = parseInt(document.querySelector('input[name="radioTired"]:checked').getAttribute("value"));
    let note = document.getElementById("surveyNote").getAttribute("value");
    console.log("Difficulty: " + difficulty + ", Pain: " + pain + ", Tiredness: " + tiredness + ", " + note );
    return {
      Completed : true,
      Date : new Date(),
      LevelOfDifficulty : difficulty,
      LevelOfPain : pain,
      LevelOfTiredness : tiredness,
      Note : note
    }
  }
}
