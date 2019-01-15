import { Component } from '@angular/core';
import { Router } from '@angular/router'

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class Login { 
    constructor(private router: Router){

    }

    checkInput(username, password) {
        this.router.navigateByUrl('./therapist-home-screen');
    }
}
