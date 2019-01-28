using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PhysicalTherapy.Models
{
    public class TherapistPatientContext : DbContext
    {
        public TherapistPatientContext (DbContextOptions<TherapistPatientContext> options)
            : base(options)
        {
        }

        public DbSet<PhysicalTherapy.Models.Patient> Patient { get; set; }
    }
}
