import { MessageLog } from "./MessageLog";
import { Patient } from "./Patient";
import { PostRoutineSurvey } from "./PostRoutineSurvey"
import { RoutineExercise } from "./RoutineExercise";

export interface Routine {
    date : Date;
    description : string,
    isComplete : boolean,
    isNew : boolean,
    listOfMessageLogs : MessageLog[],
    name : string;
    patient : Patient
    patientId : number,
    routineExercises : RoutineExercise[],
    routineId : number,
    postRoutineSurvey : PostRoutineSurvey,
    postRoutineSurveyId : number
}