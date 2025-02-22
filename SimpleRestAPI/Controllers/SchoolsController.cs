using Microsoft.AspNetCore.Mvc;
using SimpleRestAPI.Models;
using SimpleRestAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace SimpleRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController(SchoolsDbContext context) : ControllerBase
    {
        private readonly SchoolsDbContext _context = context;


        [HttpGet]
        public async Task<ActionResult<List<School>>> GetSchools()
        {
            return  Ok(await _context.Schools.ToListAsync());
        }
    }
}
