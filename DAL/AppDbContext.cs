using Microsoft.EntityFrameworkCore;
using WebApplication20.Models;

namespace WebApplication20.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
       
        public DbSet<Member> Members { get; set; }
        public DbSet<Profession> Professions { get; set; }
    }
}
