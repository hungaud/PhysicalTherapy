import { Therapist } from "./Therapist";

export interface Patient {
  [x: string]: any;
    AccountType : number,
    Bio : string,
    DateOfBirth : Date,
    Email : string,
    FirstName : string,
    LastName : string,
    PatientId : number,
    PhoneNumber : string,
    Therapist : Therapist,
    TherapistId : number,
    Username : string
}