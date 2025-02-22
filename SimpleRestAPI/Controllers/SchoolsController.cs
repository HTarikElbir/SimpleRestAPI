using Microsoft.AspNetCore.Mvc;
using SimpleRestAPI.Models;
using SimpleRestAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Mapster;

namespace SimpleRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly SchoolsDbContext _context;

        public SchoolsController(SchoolsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<School>>> GetSchools()
        {
            var schools = await _context.Schools.ToListAsync();

            if (schools == null)
            {
                return NotFound();
            }
            var response = schools.Adapt<List<SchoolDTO>>();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<School>> GetSchool(int id)
        {
            var school = await GetSchoolById(id);

            if (school == null)
            {
                return NotFound();
            }

            var response = school.Adapt<SchoolDTO>();

            return Ok(response);
        }

        private async Task<School?> GetSchoolById(int id)
        {
            var school = await _context.Schools.FindAsync(id);
            return school;
        }
    }
}
