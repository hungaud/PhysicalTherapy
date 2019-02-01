import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

import { apiEndpoint } from '../globals'
import { observable, Observable } from 'rxjs';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class Login { 
    constructor(private router: Router, private http: HttpClient){}

    loginClick(username, password, error) {
        error.innerText = '';
        this.http.get(`${apiEndpoint}/Credentials/${username.value}`)
            .subscribe((response : Response) => {
                if(response['password'] === password.value) {
                    if (response['accountType'] === 1) {
                        this.router.navigate(['./therapist-home-screen']);
                    } else if (response['accountType'] === 2) {
                        this.router.navigate(['./patient-home-screen', {username : username.value}]);
                    } else if (response['accountType'] === 0) {
                        // Navigate to admin homepage
                    }
                }
            });
        error.innerText = 'INCORRECT USERNAME OR PASSWORD';
    }
}
