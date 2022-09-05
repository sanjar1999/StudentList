using DAL.Models;
using Microsoft.EntityFrameworkCore;
#pragma warning disable

namespace DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext( DbContextOptions<ApplicationContext> options )
            : base( options )
        {
        }
        public ApplicationContext() { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
