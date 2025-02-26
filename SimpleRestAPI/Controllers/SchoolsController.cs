using Microsoft.AspNetCore.Mvc;
using SimpleRestAPI.Models;
using SimpleRestAPI.Data;
using Microsoft.EntityFrameworkCore;
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
            
            return schools == null ?NotFound() : Ok(schools.Adapt<List<SchoolDTO>>()); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolDTO>> GetSchool(int id)
        {
            var school = await GetSchoolById(id);

            return school == null ? NotFound() : Ok(school.Adapt<SchoolDTO>());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchool(int id, SchoolDTO updatedSchool)
        {
            var school = await GetSchoolById(id);
            if (school == null) 
                return NotFound();

            try
            {
                updatedSchool.Adapt(school); // Mapster ile güncelleme  
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            try
            {
                var school = await GetSchoolById(id);
                if (school == null) 
                    return NotFound();

                _context.Schools.Remove(school);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        private async Task<School?> GetSchoolById(int id)
        {
            return await _context.Schools.FindAsync(id);
        }
    }
}
