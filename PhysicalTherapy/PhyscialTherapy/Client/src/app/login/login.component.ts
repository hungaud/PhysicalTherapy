import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class Login { 
    constructor(private router: Router){ }

    loginClick(username, password) {
        // console.log(username.value + ' ' + password.value);
        // Check the username and password
        /* constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
            http.get<WeatherForecast[]>(baseUrl + 'api/Credential').subscribe(result => {
              this.forecasts = result;
            }, error => console.error(error));
          }*/
        // Navigate to the correct home screen
        this.router.navigate(['./therapist-home-screen']);
    }
}
