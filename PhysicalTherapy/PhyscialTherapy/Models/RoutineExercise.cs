using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhysicalTherapy.Models
{
    public class RoutineExercise
    {
        public Exercise Exercise { get; set; }

        public int ExerciseId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
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
