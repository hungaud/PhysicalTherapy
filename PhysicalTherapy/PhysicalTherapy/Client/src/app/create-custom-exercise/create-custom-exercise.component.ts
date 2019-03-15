import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Exercise } from '../models/Exercise';
import { ExerciseService } from '../services/exercise.service';
import { analyzeAndValidateNgModules } from '@angular/compiler';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-custom-exercise',
  templateUrl: './create-custom-exercise.component.html',
  styleUrls: ['./create-custom-exercise.component.scss']
})
export class CreateCustomExerciseComponent implements OnInit {

  exercise : Exercise;

  constructor(private modalService: NgbModal, private exerciseService : ExerciseService, private router: Router) {
    this.exercise = {} as Exercise;
  }

  ngOnInit( ) {
  }

  openCreateExercise(content) {
    this.modalService.open(content, {centered: true});
  }
  
  public save() {
    this.exerciseService.postExercise(this.exercise)
      .subscribe((result) => {
      console.log(result + "post call done");
    });
    
  }

  set setName(value: string) {
    this.exercise.name = value;
  }

  set setDescription(value: string) {
    this.exercise.description = value;
  }

  set setArea(value: string) {
    this.exercise.area = value;
  }

}
