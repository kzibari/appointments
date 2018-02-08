using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Appointments.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }

    }
}