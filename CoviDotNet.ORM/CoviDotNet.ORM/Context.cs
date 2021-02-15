using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoviDotNet.ORM
{
    public class Context : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<VaccineType> VaccineTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source =CoviDotNet.db");
        }
    }
}
