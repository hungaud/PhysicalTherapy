using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhyscialTherapy.Models
{
    public class Routine
    {
        public string Description { get; set; }

        public bool IsComplete { get; set; }

        public bool isNew { get; set; }

        public Patient Patient { get; set; }

        public int PatientId { get; set; }

        public ICollection<RoutineExercise> RoutineExercises { get; set; }

        public int RoutineId { get; set; }

        public PostRoutineSurvey PostRoutineSurvey { get; set; }

        public int? PostRoutineSurveyId { get; set; }
    }
}
