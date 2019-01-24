import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TherapistHomeScreenComponent } from './therapist-home-screen/therapist-home-screen.component';
import { TherapistRosterComponent } from './therapist-roster/therapist-roster.component';
import { Login } from './login/login.component'
import { HttpClientModule } from '@angular/common/http';
import { TesttestComponent } from './testtest/testtest.component';
import { PatientHomeScreenComponent } from './patient-home-screen/patient-home-screen.component';

@NgModule({
  declarations: [
    AppComponent,
    TherapistHomeScreenComponent,
    TherapistRosterComponent,
    Login,
    TesttestComponent,
    PatientHomeScreenComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
