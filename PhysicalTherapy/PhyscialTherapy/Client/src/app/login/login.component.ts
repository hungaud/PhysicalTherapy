import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

import { apiEndpoint } from '../globals'
import { observable, Observable } from 'rxjs';
import { PatientService } from '../services/patient.service';
import { TherapistService } from '../services/therapist.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class Login {
    constructor(private router: Router, private http: HttpClient,
        private patientService: PatientService, private therapistService: TherapistService){}

    loginClick(username, password, error) {
        error.innerText = '';
        this.http.get(`${apiEndpoint}/Credentials/${username.value}`)
            .subscribe((response : Response) => {
                if(response['password'] !== password.value) {
                    error.innerText = 'INCORRECT USERNAME OR PASSWORD';
                } else {
                    if (response['accountType'] === 1) {
                        this.therapistService.getTherapistByUsername(response['username'])
                            .subscribe((response) => {
                                const key = {
                                    accountType: 1,
                                    id: response.therapistId
                                };
                                sessionStorage.setItem('user', JSON.stringify(key));
                                this.router.navigate(['./therapist-home-screen']);
                            });
                    } else if (response['accountType'] === 2) {
                        this.patientService.getPatient(response['username'])
                            .subscribe((response) => {
                                const key = {
                                    accountType: 2,
                                    id: response.patientId
                                };
                                sessionStorage.setItem('user', JSON.stringify(key));
                                this.router.navigate(['./patient-home-screen']);
                            });
                    } else if (response['accountType'] === 0) {
                        // Navigate to admin homepage
                    }
                }
            }, Err => {
                error.innerText = 'INCORRECT USERNAME OR PASSWORD';
            });
    }
}
