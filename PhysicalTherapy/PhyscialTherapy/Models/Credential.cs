using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhysicalTherapy.Models
{
    public class Credential
    {
        public int AccountTypeId { get; set; }

        public AccountType AccountType { get; set; }

        public int CredentialId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
