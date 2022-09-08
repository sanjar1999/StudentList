using DAL;
using DAL.Models;
using DTOs.Models;
using Microsoft.EntityFrameworkCore;
#pragma warning disable

namespace DTOs.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationContext _db;
        public StudentService( ApplicationContext db )
        {
            _db = db;
        }

        public async Task<List<StudentDTO>> GetStudents()
        {
            try
            {
                var list = await _db.Students.Where( y => y.IsDeleted == false )
                                             .Select( x => new StudentDTO
                                             {
                                                 Id = x.Id,
                                                 Name = x.Name,
                                                 Country = x.Country,
                                                 TeacherId = x.TeacherId,
                                                 DateOfCreation = x.DateOfCreation,
                                                 Teacher = x.Teacher,
                                                 Contract = x.Contract,
                                                 Status = x.Status,
                                             } ).ToListAsync();

                return list;
            }
            catch ( Exception e )
            {
                throw new ArgumentException( nameof( e ) );
            }
        }

        public async Task<StudentDTO> GetStudentById( int id )
        {
            try
            {
                if ( id == null )
                {
                    throw new ArgumentNullException( nameof( id ) );
                }

                var dbData = await _db.Students
                                    .Include( x => x.Teacher )
                                    .FirstOrDefaultAsync( x => x.Id == id );

                if ( dbData == null || dbData.IsDeleted == true )
                {
                    throw new ArgumentNullException( "Student not found" );
                }

                var res = new StudentDTO
                {
                    Id = dbData.Id,
                    Name = dbData.Name,
                    Country = dbData.Country,
                    TeacherId = dbData.TeacherId,
                    DateOfCreation = dbData.DateOfCreation,
                    Contract = dbData.Contract,
                    Status = dbData.Status,
                    Teacher = dbData.Teacher,
                };

                return res;
            }
            catch ( Exception e )
            {
                throw new ArgumentException( nameof( e ) );
            }
        }

        public async Task UpdateStudent( int id, CreateUpdateStudentDTO studentDTO )
        {
            try
            {
                if ( id == null || studentDTO == null )
                {
                    throw new ArgumentNullException( nameof( id ) );
                }

                var studentUpdate = await _db.Students.FirstOrDefaultAsync( x => x.Id == id );

                if ( studentUpdate == null )
                {
                    throw new ArgumentNullException( nameof( studentUpdate ) );
                }

                studentUpdate.Name = studentDTO.Name;
                studentUpdate.Country = studentDTO.Country;
                studentUpdate.TeacherId = studentDTO.TeacherId;
                studentUpdate.DateOfCreation = DateTime.Now;
                studentUpdate.Contract = studentDTO.Contract;
                studentUpdate.Status = studentDTO.Status;

                await _db.SaveChangesAsync();
            }
            catch ( Exception e )
            {
                throw new ArgumentException( nameof( e ) );
            }
        }

        public async Task DeleteStudent( int id )
        {
            try
            {
                if ( id == null )
                {
                    throw new ArgumentNullException( nameof( id ) );
                }

                var student = _db.Students
                                          .Where( s => s.Id == id && s.IsDeleted == false )
                                          .FirstOrDefault();

                student.IsDeleted = true;
                await _db.SaveChangesAsync();
            }
            catch ( Exception e )
            {
                throw new ArgumentException( nameof( e ) );
            }
        }

        public async Task CreateStudent( CreateUpdateStudentDTO studentDTO )
        {
            try
            {
                if ( studentDTO == null )
                {
                    throw new ArgumentNullException( nameof( studentDTO ) );
                }

                var newStudent = new Student
                {
                    Name = studentDTO.Name,
                    Country = studentDTO.Country,
                    TeacherId = studentDTO.TeacherId,
                    DateOfCreation = studentDTO.DateOfCreation,
                    Contract = studentDTO.Contract,
                    Status = studentDTO.Status
                };

                await _db.Students.AddAsync( newStudent );
                await _db.SaveChangesAsync();
            }
            catch ( Exception e )
            {
                throw new ArgumentException( nameof( e ) );
            }
        }
    }
}
