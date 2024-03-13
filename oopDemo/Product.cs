using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oopDemo
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string? Name { get; set; }
        public int Calories { get; set; }
        public string? Color { get; set; }
        public string? Flavor { get; set; }
    }
}
