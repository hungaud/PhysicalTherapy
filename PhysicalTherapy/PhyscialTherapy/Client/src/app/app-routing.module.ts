import { Login } from './login/login.component'
import { NgModule } from '@angular/core';
import { PatientHomeScreenComponent } from './patient-home-screen/patient-home-screen.component';
import { Routes, RouterModule } from '@angular/router';
import { TherapistHomeScreenComponent } from './therapist-home-screen/therapist-home-screen.component';
import { TherapistRosterComponent } from './therapist-roster/therapist-roster.component';
import { AddPatientComponent } from './add-patient/add-patient.component';
import { RoutinePageComponent } from './routine-page/routine-page.component';
import { TherapistRoutineCreationScreenComponent } from './therapist-routine-creation-screen/therapist-routine-creation-screen.component';
import { CreateCustomExerciseComponent } from './create-custom-exercise/create-custom-exercise.component';


const routes: Routes = [
  {path: '', component: Login},
  {path: 'therapist-home-screen', component: TherapistHomeScreenComponent},
  {path: 'add-patient-screen', component: AddPatientComponent},
  {path: 'routine-page', component: RoutinePageComponent},  
  {path: 'patient-home-screen', component: PatientHomeScreenComponent },
  {path: 'therapist-roster-screen', component: TherapistRosterComponent},
  {path: 'therapist-routine-creation-screen', component: TherapistRoutineCreationScreenComponent},
  {path: 'create-custom-exercise', component: CreateCustomExerciseComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
