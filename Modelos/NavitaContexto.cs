using Navita.Avaliacao.Modelos.Configuracoes;
using Microsoft.EntityFrameworkCore;

namespace Navita.Avaliacao.Modelos
{
    public class NavitaContexto : DbContext
    {
        public NavitaContexto(DbContextOptions<NavitaContexto> options)
         : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfiguracaoMarca());
            modelBuilder.ApplyConfiguration(new ConfiguracaoPatrimonio());
            modelBuilder.ApplyConfiguration(new ConfiguracaoUsuario());
        }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Patrimonio> Patrimonios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}