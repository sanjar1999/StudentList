using DTOs.Models;
using DTOs.Services;
using Microsoft.AspNetCore.Mvc;

namespace StudentList.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController( IStudentService studentService )
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListOfStudents()
        {
            return Ok( await _studentService.GetStudents() );
        }

        [HttpGet]
        [Route( "{id}" )]
        public async Task<IActionResult> GetStudentById( int id )
        {
            return Ok( await _studentService.GetStudentById( id ) );
        }

        [HttpPut]
        [Route( "{id}" )]
        public async Task<IActionResult> UpdateStudent( int id, CreateUpdateStudentDTO studentDTO )
        {
            await _studentService.UpdateStudent( id, studentDTO );
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent( CreateUpdateStudentDTO studentDTO )
        {
            await _studentService.CreateStudent( studentDTO );
            return Ok();
        }

        [HttpDelete]
        [Route( "{id}" )]
        public async Task<IActionResult> DeleteStudent( int id )
        {
            await _studentService.DeleteStudent( id );
            return Ok();
        }
    }
}
