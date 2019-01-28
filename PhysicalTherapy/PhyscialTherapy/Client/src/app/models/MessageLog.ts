import { Patient } from "./Patient";
import { Routine } from "./Routine";
import { Therapist } from "./Therapist";

export interface MessageLog {
    insertDate : Date,
    message : string,
    messageLogId : number,
    patient : Patient,
    patientId : number,
    routine : Routine,
    routineId : number,
    therapist : Therapist,
    therapistId : number

}
