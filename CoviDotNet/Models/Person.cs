using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoviDotNet.Models
{
    public class Person
    {

        [Key]
        public int PersonId { get; set; }

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public DateTime BirthDate { get; set; }

        public string Sex { get; set; }

        public bool IsResident { get; set; }

    }
}
