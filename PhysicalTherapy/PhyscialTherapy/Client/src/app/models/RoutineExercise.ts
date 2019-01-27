import { Routine } from "./routine";

export interface RoutineExercise {
    ExerciseId : number,
    HoldLength : number,
    FrequencyPerDay : number,
    Notes : string,
    Rep : number,
    RoutineExerciseId : number,
    Routine : Routine,
    RoutineId : number,
    Sets : number
}
