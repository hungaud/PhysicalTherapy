import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeViewComponent } from './home-view/home-view.component';
import { PatientRosterComponent } from './patient-roster/patient-roster.component';

const routes: Routes = [
  { path:'homeView', component: HomeViewComponent },
  { path:'patientRoster', component: PatientRosterComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
