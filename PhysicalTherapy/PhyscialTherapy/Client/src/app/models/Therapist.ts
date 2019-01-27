import { Patient } from "./Patient";

export interface Therapist {
    AccountType : number,
    Bio : string,
    DateOfBirth : Date,
    Email : string,
    FirstName : string,
    LastName : string,
    ListOfPatients : Patient[],
    PhoneNumber : string,
    TherapistId : number,
    Username : string
}
