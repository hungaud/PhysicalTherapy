import { Component, OnInit } from '@angular/core';
import { RoutineService } from '../services/routine.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-routine-page',
  templateUrl: './routine-page.component.html',
  styleUrls: ['./routine-page.component.scss']
})

export class RoutinePageComponent implements OnInit {

  constructor(private route : ActivatedRoute, private routineService : RoutineService) { }

  ngOnInit() {
  }

}
