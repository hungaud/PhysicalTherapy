import { AppComponent } from './app.component';

import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { Login } from './login/login.component'
import { MessagesComponent } from './messages/messages.component';
import { NgModule, InjectionToken } from '@angular/core';
import { PatientHomeScreenComponent } from './patient-home-screen/patient-home-screen.component';
import { PatientService } from './services/patient.service';
import { RoutinePageComponent } from './routine-page/routine-page.component';
import { RoutineService } from './services/routine.service';
import { RouterModule } from '@angular/router';
import { TherapistHomeScreenComponent } from './therapist-home-screen/therapist-home-screen.component';
import { TherapistRosterComponent } from './therapist-roster/therapist-roster.component';
import { AddPatientComponent } from './add-patient/add-patient.component';
@NgModule({
  declarations: [
    AppComponent,
    TherapistHomeScreenComponent,
    TherapistRosterComponent,
    Login,
    AddPatientComponent,
    //TesttestComponent,
    PatientHomeScreenComponent,
    MessagesComponent,
    RoutinePageComponent,
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
