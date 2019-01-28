import { Therapist } from "./Therapist";

export interface Patient {
    accountType : number,
    bio : string,
    dateOfBirth : Date,
    email : string,
    firstName : string,
    lastName : string,
    patientId : number,
    phoneNumber : string,
    therapist : Therapist,
    therapistId : number,
    username : string
}