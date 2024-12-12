using System.ComponentModel.DataAnnotations;

namespace End_Point_Parameters_Task.Models
{
    public class Product
    {
        [Key]
        public int PID { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }
        [Required]
        public string Category { get; set;} = "general";
        [Required]
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

    }
}
