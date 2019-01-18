import { Component, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { CredentialService } from './Credential.service'

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class Login { 
    constructor(private router: Router, private credServ: CredentialService){ }

    loginClick(username, password) {
        //console.log(username.value + ' ' + password.value);
        // Check the username and password
        const result = this.credServ.getUser(username.value);
        console.log(JSON.stringify(result.source));
        // Navigate to the correct home screen
        this.router.navigate(['./therapist-home-screen']);
    }
}
