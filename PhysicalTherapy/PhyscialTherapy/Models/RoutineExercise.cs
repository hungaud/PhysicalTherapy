using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhysicalTherapy.Models
{
    public class RoutineExercise
    {
        public Excercise Excersise { get; set; }

        public string ExerciseId { get; set; }

        public decimal? HoldLength { get; set; }

        public int? FrequencyPerDay { get; set; }

        public string Notes { get; set; }

        public int? Rep { get; set; }

        public int RoutineExerciseId { get; set; }

        public Routine Routine { get; set; }

        public int RoutineId { get; set; }

        public int? Sets { get; set; }

    }
}
