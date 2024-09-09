using Microsoft.EntityFrameworkCore;
using ModuloAPI.Entities;

namespace ModuloAPI.Context
{
    public class AgendaDbContext(IConfiguration configuration, DbContextOptions options) : DbContext(options)
    {
        private readonly IConfiguration _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Contato> Contatos { get; set; }
    }
}