using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhyscialTherapy.Models
{
    public class Patient
    {
        // maybe area. might have to change db.

        //public string AreaOfFocus { get; set; }

        public string Bio { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PatientId { get; set; }

        public string PhoneNumber { get; set; }

        public Therapist Therapist { get; set; }

        public int TherapistId { get; set; }

    }
}
