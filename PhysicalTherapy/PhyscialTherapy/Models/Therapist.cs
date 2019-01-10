using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhysicalTherapy.Models
{
    public class Therapist
    {
        public AccountType AccountType { get; set; }

        public int AccountTypeId { get; set; }

        public string Bio { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Patient> ListOfPatients { get; set; }

        public string PhoneNumber { get; set; }

        public int TherapistId { get; set; }

    }
}
