using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoviDotNet.ORM
{
    public class Vaccine
    {

        [Key]
        public int VaccineId { get; set; }

        public string Brand { get; set; }

        public string Disease { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int ValidityPeriod { get; set; }
    }
}
