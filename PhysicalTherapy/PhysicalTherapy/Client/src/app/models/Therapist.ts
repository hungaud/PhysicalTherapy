import { Patient } from "./Patient";

export interface Therapist {
    accountType : number,
    bio : string,
    dateOfBirth : Date,
    email : string,
    firstName : string,
    lastName : string,
    listOfPatients : Patient[],
    phoneNumber : string,
    therapistId : number,
    username : string
}
