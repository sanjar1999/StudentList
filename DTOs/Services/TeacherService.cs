using DAL;
using DAL.Models;
using DTOs.Models;
#pragma warning disable

namespace DTOs.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ApplicationContext _db;
        public TeacherService( ApplicationContext applicationContext )
        {
            _db = applicationContext;
        }

        public async Task CreateTeacher( TeacherDTO teacherDTO )
        {
            try
            {
                if ( teacherDTO == null )
                {
                    throw new ArgumentNullException( nameof( teacherDTO ) );
                }

                var newTeacher = new Teacher
                {
                    Name = teacherDTO.Name,
                };

                await _db.Teachers.AddAsync( newTeacher );
                await _db.SaveChangesAsync();
            }
            catch ( Exception e )
            {
                throw new ArgumentException( nameof( e ) );
            }
        }
    }
}
