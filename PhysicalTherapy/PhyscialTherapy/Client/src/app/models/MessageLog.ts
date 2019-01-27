import { Patient } from "./Patient";
import { Routine } from "./Routine";
import { Therapist } from "./Therapist";

export interface MessageLog {
    InsertDate : Date,
    Message : string,
    MessageLogId : number,
    Patient : Patient,
    PatientId : number,
    Routine : Routine,
    RoutineId : number,
    Therapist : Therapist,
    TherapistId : number

}
