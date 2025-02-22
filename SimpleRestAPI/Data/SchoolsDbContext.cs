using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SimpleRestAPI.Models;

namespace SimpleRestAPI.Data
{
    public class SchoolsDbContext(DbContextOptions<SchoolsDbContext> options) :DbContext(options)
    {
        public DbSet<School> Hotels => Set<School>();
    }
}
