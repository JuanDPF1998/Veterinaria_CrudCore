using Microsoft.EntityFrameworkCore;
using Veterinaria_crudcore.Models;

namespace Veterinaria_crudcore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options): base(options) { }
        public DbSet<Mascotas> mascotas { get; set; }
    }
}
