using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhysicalTherapy.Models
{
    public class PostRoutineSurvey
    {
        public bool Completed { get; set; }

        [Range(1, 10)]
        public decimal LevelOfDifficulty { get; set; }

        [Range(1, 10)]
        public decimal LevelOfPain { get; set; }

        [Range(1, 10)]
        public decimal LevelOfTiredness { get; set; }

        public string Note { get; set; }

        public int PostRoutineSurveyId { get; set; }

        public Routine Routine { get; set; }

        public int RoutineId { get; set; }
    }
}
