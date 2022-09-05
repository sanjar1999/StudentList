using DTOs.Models;

namespace DTOs.Services
{
    public interface ITeacherService
    {
        Task CreateTeacher(TeacherDTO teacherDTO);
    }
}
