using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhysicalTherapy.Models
{
    public class MessageLog
    {
        public DateTime InsertDate { get; set; }

        public string Message { get; set; }

        public int MessageLogId { get; set; }

        public Patient Patient { get; set; }

        public int? PatientId { get; set; }

        public Routine Routine { get; set; }

        public int? RoutineId { get; set; }

        public Therapist Therapist { get; set; }

        public int? TherapistId { get; set; }
    }
}
