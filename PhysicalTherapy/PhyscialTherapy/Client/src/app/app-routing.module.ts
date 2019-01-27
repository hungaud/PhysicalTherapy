import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TherapistHomeScreenComponent } from './therapist-home-screen/therapist-home-screen.component';
import { TherapistRosterComponent } from './therapist-roster/therapist-roster.component';
import { Login } from './login/login.component';
import { AddPatientComponent } from './add-patient/add-patient.component';

const routes: Routes = [
  {path: '', component: Login},
  {path: 'therapist-home-screen', component: TherapistHomeScreenComponent},
  {path: 'therapist-roster-screen', component: TherapistRosterComponent},
  {path: 'add-patient-screen', component: AddPatientComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
