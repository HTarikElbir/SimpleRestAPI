using Microsoft.EntityFrameworkCore;
using SimpleRestAPI.Models;

namespace SimpleRestAPI.Data
{
    public class SchoolsDbContext(DbContextOptions<SchoolsDbContext> options) :DbContext(options)
    {
        public DbSet<School> Schools => Set<School>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<School>().HasData(
               new School
               {
                   Id = 1,
                   Name = "School 1",
                   Address = "Address 1",
                   City = "City 1",
                   SecretValue = "Secret 1"
               },
               new School
               {
                   Id = 2,
                   Name = "School 2",
                   Address = "Address 2",
                   City = "City 2",
                   SecretValue = "Secret 2"
               },
               new School
               {
                   Id = 3,
                   Name = "School 3",
                   Address = "Address 3",
                   City = "City 3",
                   SecretValue = "Secret 3"
               },
               new School
               {
                   Id = 4,
                   Name = "School 4",
                   Address = "Address 4",
                   City = "City 4",
                   SecretValue = "Secret 4"
               },
               new School
               {
                   Id = 5,
                   Name = "School 5",
                   Address = "Address 5",
                   City = "City 5",
                   SecretValue = "Secret 5"
               }
           );

        }
    }
}
