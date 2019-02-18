import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-shared-background',
  templateUrl: './shared-background.component.html',
  styleUrls: ['./shared-background.component.scss']
})
export class SharedBackgroundComponent implements OnInit {
  public home : string = "";

  constructor(private router : Router) { }

  ngOnInit() {
    this.setHome();
    
  }

  private setHome() {
    if(sessionStorage.getItem("user") !== null) {
      const user = JSON.parse(sessionStorage.getItem('user'));
      //console.log("user:   " + JSON.stringify(user))

      if(user.accountType === 0) 
        this.home = "";
      else if (user.accountType === 1)
        this.home = "/therapist-home-screen";
      else if (user.accountType === 2)
        this.home = "/patient-home-screen";
      else
        this.home = "";
    }
  }

}
