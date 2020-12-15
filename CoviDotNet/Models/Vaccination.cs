using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoviDotNet.Models
{
    public class Vaccination
    {

        [Key]
        public int VaccinationId { get; set; }

        public Person Person { get; set; }

        public Vaccine Vaccine { get; set; }

        public DateTime VaccinationDate { get; set; }

        public string Lot { get; set; }

        public DateTime ReminderDate { get; set; }

    }
}
