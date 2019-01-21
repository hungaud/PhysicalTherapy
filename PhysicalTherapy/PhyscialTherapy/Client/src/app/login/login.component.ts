import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class Login { 
    constructor(private router: Router, private http: HttpClient){ }

    // TODO: Add routing to patient homepage
    loginClick(username, password, error) {
        error.innerText = '';
        this.http.get(`http://localhost:64496/api/Credentials/${username.value}`)
            .subscribe((response) => {
                if (response['password'] !== password.value) {
                    error.innerText = 'INCORRECT USERNAME OR PASSWORD';
                }

                if (response['accountType'] === 1) {
                    this.router.navigate(['./therapist-home-screen']);
                } else if (response['accountType'] === 2) {
                    // Navigate to patient homepage
                } else if (response['accountType'] === 0) {
                    // Navigate to admin homepage
                }
            });
    }
}
