using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhysicalTherapy.Models
{
    public class SetRepLog
    {
        public int SetNumber { get; set; }
        
        public int ReportedNumber { get; set; }

        [Key]
        public int SetRepLogId { get; set; }

        public int PostRoutineSurveyId { get; set; }

        public PostRoutineSurvey PostRoutineSurvey { get; set; }
    }
}