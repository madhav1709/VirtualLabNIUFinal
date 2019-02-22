using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VirtualLab.Areas.Identity.Data;

namespace VirtualLab.Models
{
    public class Context : IdentityDbContext<VirtualLabUser>
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

		public DbSet<Course> Course { get; set; }
		public DbSet<Announcements> Announcements { get; set; }
		public DbSet<Assignments> Assignments { get; set; }
		public DbSet<Grades> Grades { get; set; }
		public DbSet<StudentCourse> StudentCourse { get; set; } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
