using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KTB.Models
{
    public class Vendor
    {
        [Key]
        public int Vendor_Id { get; set; }
        [Required]
        public string Vendor_Name { get; set; }
        public string Nationality { get; set; }
        public DateTime DoB { get; set; }
        public List<Fruit> Fruits { get; set; }
    }
}
