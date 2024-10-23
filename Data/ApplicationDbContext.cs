using Microsoft.EntityFrameworkCore;
using Todo_App_Backend.Models.Entities;

namespace Todo_App_Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Notes> Notes { get; set; }
    }
}
