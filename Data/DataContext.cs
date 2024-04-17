using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using repository_pattern.Model;
using System.Collections.Generic;
using System.Data.Common;

namespace repository_pattern.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<Student>Students { get; set; }
        public DbSet<Teacher>Teacher { get; set; }
        public DbSet<Review>Reviews { get; set; }
    }
}
