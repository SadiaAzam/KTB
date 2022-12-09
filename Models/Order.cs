using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTB.Models
{
    public class Order
    {
        [Key]
        public int Order_Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Status { get; set; }

        public DateTime LastUpdate { get; set; }
       


    }
}
