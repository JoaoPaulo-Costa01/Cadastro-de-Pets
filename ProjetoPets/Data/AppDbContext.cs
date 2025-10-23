using Microsoft.EntityFrameworkCore;
using ProjetoPets.Models;

namespace ProjetoPets.Data {
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions options) : base(options) {
        }
        
        public DbSet<Pets> Bichinhos { get; set; } 
    }
}
