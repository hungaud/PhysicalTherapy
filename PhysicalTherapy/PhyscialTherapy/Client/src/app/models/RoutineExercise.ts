import { Routine } from "./routine";

export interface RoutineExercise {
    exerciseId : number,
    holdLength : number,
    frequencyPerDay : number,
    notes : string,
    rep : number,
    routineExerciseId : number,
    routine : Routine,
    routineId : number,
    sets : number
}
