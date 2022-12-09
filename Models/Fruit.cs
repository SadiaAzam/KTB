using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTB.Models
{
    public class Fruit
    {
       [Key]
      public int id { get; set; }
        [Required]
      public string Tital { get; set; }
        [Required]
      public string URL { get; set; }
        [Required]
        public int Price { get; set; }
        //foreign key
         [ForeignKey("Emlpoyees")]
       public int Employee_Id { get; set; }
       public virtual Employee Employees { get; set; }
        public List<Vendor> Vendors { get; set; }
    }
}
