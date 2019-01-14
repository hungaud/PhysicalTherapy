using PhysicalTherap.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhysicalTherapy.Models
{
    public class Administrator
    {
        public AccountType AccountType { get; set; }

        public int AccountTypeId { get; set; }

        public int AdministratorId { get; set; }

        public string Bio { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string Username { get; set; }
    }
}
