import { AppComponent } from './app.component';

import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { Login } from './login/login.component'
import { NgModule, InjectionToken } from '@angular/core';
import { PatientHomeScreenComponent } from './patient-home-screen/patient-home-screen.component';
import { RoutineService } from './services/routine.service';
import { TherapistHomeScreenComponent } from './therapist-home-screen/therapist-home-screen.component';
import { TherapistRosterComponent } from './therapist-roster/therapist-roster.component';
import { PatientService } from './services/patient.service';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    TherapistHomeScreenComponent,
    TherapistRosterComponent,
    Login,
    //TesttestComponent,
    PatientHomeScreenComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule
  ],
  providers: [
    RoutineService,
    PatientService,
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
