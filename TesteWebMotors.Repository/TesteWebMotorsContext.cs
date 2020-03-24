using TesteWebMotors.Model;
using Microsoft.EntityFrameworkCore;


namespace TesteWebMotors.Repository
{
    public class TesteWebMotorsContext : DbContext
    {
        public TesteWebMotorsContext()
        {

        }

        public TesteWebMotorsContext(DbContextOptions<TesteWebMotorsContext> options) : base(options) { }

        public DbSet<Anuncio> Anuncio { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Modelo> Modelo { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Versao> Versao { get; set; }
    }
}
