import { Component, OnInit } from '@angular/core';
import { RoutineService } from '../services/routine.service';
import { ActivatedRoute } from '@angular/router';
import { Routine } from '../models/routine';
import { RoutineExercise } from '../models/routineExercise';
import { isNullOrUndefined } from 'util';
import { PostRoutineSurvey } from '../models/PostRoutineSurvey';
import { SSL_OP_SSLEAY_080_CLIENT_DH_BUG } from 'constants';
import { timer, Subscription } from 'rxjs';


@Component({
  selector: 'app-routine-page',
  templateUrl: './routine-page.component.html',
  styleUrls: ['./routine-page.component.scss']
})

export class RoutinePageComponent implements OnInit {

  constructor(private route : ActivatedRoute,
    private routineService : RoutineService) { }

  public routineId : number;
  public exerciseList : RoutineExercise[];
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
    let postRoutineSurvey = this.collectSurveyInfo();
  }

  collectSurveyInfo() {
    let difficulty = parseInt(document.querySelector('input[name="radioDifficulty"]:checked').getAttribute("value"));
    let pain = parseInt(document.querySelector('input[name="radioPain"]:checked').getAttribute("value"));
    let tiredness = parseInt(document.querySelector('input[name="radioTired"]:checked').getAttribute("value"));
    let note = document.getElementById("surveyNote").getAttribute("value");
    console.log("Difficulty: " + difficulty + ", Pain: " + pain + ", Tiredness: " + tiredness + ", " + note );
    return {
      completed : true,
    levelOfDifficulty : difficulty,
    levelOfPain : pain,
    levelOfTiredness : tiredness,
    note : note,
    postRoutineSurveyId : null }
  }
}
