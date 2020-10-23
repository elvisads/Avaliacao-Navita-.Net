using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Navita.Avaliacao.Modelos.Configuracoes
{
    public class ConfiguracaoMarca : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.ToTable("MARCA");
            builder.HasKey(p => p.MarcaId);
            builder.Property(p => p.MarcaId).HasColumnName("MARCA_ID");
            builder.Property(p => p.Nome).IsRequired().HasColumnName("NOME");
        }
    }
}