using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhysicalTherapy.Models
{
    public class Excercise
    {
        public string Area { get; set; }

        public string Description { get; set; }

        public int ExcerciseId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
