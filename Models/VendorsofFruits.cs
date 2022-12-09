using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTB.Models
{
    public class VendorsofFruits
    {
        [Key]
        public int Id { get; set; }
        //foreign key
        [ForeignKey("Fruits")]
        public int FruitId { get; set; }
        public virtual Fruit Fruits { get; set; }
        //foreign key
        [ForeignKey("Vendors")]
        public int VendorId { get; set; }
        public virtual Vendor Vendors { get; set; }
    }
}
