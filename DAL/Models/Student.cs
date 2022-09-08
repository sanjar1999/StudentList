using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#pragma warning disable

namespace DAL.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        [ForeignKey( "Teacher" )]
        public int TeacherId { get; set; }
        [Required]
        public DateTime DateOfCreation { get; set; }
        [Required]
        public int Contract { get; set; }
        [Required]
        [Range( 0, 5 )]
        public Status Status { get; set; }
        public Teacher Teacher { get; set; }
        public bool IsDeleted { get; set; }
    }

    public enum Status
    {
        Proposal,
        Unqualified,
        Qualified,
        Renewal,
        Negotitation
    }
}
