using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KTB.Models
{
    public class Employee
    {
        [Key]
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public List<Fruit> Fruits { get; set; }

    }
}
