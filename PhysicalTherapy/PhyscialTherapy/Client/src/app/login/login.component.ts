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
                if(response['password'] !== password.value) {
                    error.innerText = 'INCORRECT USERNAME OR PASSWORD';
                } else {
                    const key = {
                        accountType: response['accountType'],
                        username: response['username']
                    };
                    if (response['accountType'] === 1) {
                        sessionStorage.setItem('user', JSON.stringify(key));
                        this.router.navigate(['./therapist-home-screen']);
                    } else if (response['accountType'] === 2) {
                        sessionStorage.setItem('user', JSON.stringify(key));
                        this.router.navigate(['./patient-home-screen', {username : username.value}]);
                    } else if (response['accountType'] === 0) {
                        // Navigate to admin homepage
                    }
                }
            }, Err => {
                error.innerText = 'INCORRECT USERNAME OR PASSWORD';
            });
    }
}
