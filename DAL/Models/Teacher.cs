using System.ComponentModel.DataAnnotations;
#pragma warning disable

namespace DAL.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}