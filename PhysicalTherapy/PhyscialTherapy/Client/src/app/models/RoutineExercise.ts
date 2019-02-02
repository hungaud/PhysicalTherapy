import { Routine } from "./Routine";
import { Exercise } from "./Exercise";

export interface RoutineExercise {
    exercise : Exercise,
    exerciseId : number,
    frequencyPerDay : number,
    holdLength : number,
    notes : string,
    rep : number,
    routineExerciseId : number,
    routine : Routine,
    routineId : number,
    sets : number
}
