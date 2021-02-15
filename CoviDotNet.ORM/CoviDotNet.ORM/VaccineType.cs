using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoviDotNet.ORM
{
    public class VaccineType
    {
        [Key]
        public int VaccineTypeId { get; set; }

        public string Name { get; set; }
    }
}
