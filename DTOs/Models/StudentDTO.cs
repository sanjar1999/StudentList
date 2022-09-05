using DAL.Models;
#pragma warning disable

namespace DTOs.Models
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int TeacherId { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int Contract { get; set; }
        public Status Status { get; set; }
        public Teacher Teacher { get; set; }
    }
}
