using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhysicalTherapy.Models
{
    public class Routine
    {
        public string Description { get; set; }

        public bool IsComplete { get; set; }

        public bool isNew { get; set; }

        public ICollection<MessageLog> ListOfMessageLogs { get; set; }

        public Patient Patient { get; set; }

        public int PatientId { get; set; }

        public ICollection<RoutineExercise> RoutineExercises { get; set; }

        public int RoutineId { get; set; }

        [ForeignKey("PostRoutineSurveyId")]
        public PostRoutineSurvey PostRoutineSurvey { get; set; }

        public int? PostRoutineSurveyId { get; set; }
    }
}
