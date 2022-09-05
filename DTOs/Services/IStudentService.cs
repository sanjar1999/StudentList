using DTOs.Models;

namespace DTOs.Services
{
    public interface IStudentService
    {
        Task<List<StudentDTO>> GetStudents();
        Task<StudentDTO> GetStudentById( int id );
        Task UpdateStudent( int id, CreateUpdateStudentDTO studentDTO );
        Task DeleteStudent( int id );
        Task CreateStudent( CreateUpdateStudentDTO studentDTO );
    }
}
