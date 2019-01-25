import { Login } from './login/login.component'
import { NgModule } from '@angular/core';
import { PatientHomeScreenComponent } from './patient-home-screen/patient-home-screen.component';
import { Routes, RouterModule } from '@angular/router';
import { TherapistHomeScreenComponent } from './therapist-home-screen/therapist-home-screen.component';
import { TherapistRosterComponent } from './therapist-roster/therapist-roster.component';


const routes: Routes = [
  {path: '', component: Login},
  {path: 'therapist-home-screen', component: TherapistHomeScreenComponent},
  {path: 'patient-home-screen', component: PatientHomeScreenComponent },
  {path: 'therapist-roster-screen', component: TherapistRosterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
