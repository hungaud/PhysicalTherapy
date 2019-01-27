import { MessageLog } from "./MessageLog";
import { Patient } from "./Patient";
import { PostRoutineSurvey } from "./PostRoutineSurvey"
import { RoutineExercise } from "./RoutineExercise";

export interface Routine {
    Description : string,
    IsComplete : boolean,
    IsNew : boolean,
    ListOfMessageLogs : MessageLog[],
    Patient : Patient
    PatientId : number,
    RoutineExercises : RoutineExercise[],
    RoutineId : number,
    PostRoutineSurvey : PostRoutineSurvey,
    PostRoutineSurveyId : number
}