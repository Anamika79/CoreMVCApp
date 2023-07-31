using CoreMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreMVCApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }

        



    }
}
