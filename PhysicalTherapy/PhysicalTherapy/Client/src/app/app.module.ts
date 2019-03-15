import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Login } from './login/login.component'
import { MessagesComponent } from './messages/messages.component';
import { NgModule, InjectionToken } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { PatientHomeScreenComponent } from './patient-home-screen/patient-home-screen.component';
import { PatientService } from './services/patient.service';
import { RoutinePageComponent } from './routine-page/routine-page.component';
import { RoutineService } from './services/routine.service';
import { RouterModule } from '@angular/router';
import { TherapistHomeScreenComponent } from './therapist-home-screen/therapist-home-screen.component';
import { TherapistRosterComponent } from './therapist-roster/therapist-roster.component';
import { AddPatientComponent } from './add-patient/add-patient.component';
import { TherapistRoutineCreationScreenComponent } from './therapist-routine-creation-screen/therapist-routine-creation-screen.component';
import { ExerciseService } from './services/exercise.service';
import { DecimalPipe } from '@angular/common';
//import { NgbdTableFiltering } from './/table-filtering';
import { TherapistService } from './services/therapist.service';
import { RoutineExerciseService } from './services/routineExercise.service';
import { CreateCustomExerciseComponent } from './create-custom-exercise/create-custom-exercise.component';
import { SharedBackgroundComponent } from './shared/shared-background/shared-background.component';

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
    TherapistRoutineCreationScreenComponent,
    CreateCustomExerciseComponent,
    SharedBackgroundComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
    NgbModule,
    ReactiveFormsModule,
    ],
  providers: [
    RoutineService,
    PatientService,
    ExerciseService,
    TherapistService,
    RoutineExerciseService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
