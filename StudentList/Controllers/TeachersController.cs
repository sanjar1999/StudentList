using DTOs.Models;
using DTOs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentList.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeachersController( ITeacherService teacherService )
        {
            _teacherService = teacherService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher( TeacherDTO teacherDTO )
        {
            await _teacherService.CreateTeacher( teacherDTO );
            return Ok();
        }
    }
}
