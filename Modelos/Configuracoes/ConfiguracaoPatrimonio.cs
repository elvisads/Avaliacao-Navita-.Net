using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Navita.Avaliacao.Modelos.Configuracoes
{
    public class ConfiguracaoPatrimonio : IEntityTypeConfiguration<Patrimonio>
    {
        public void Configure(EntityTypeBuilder<Patrimonio> builder)
        {
            builder.ToTable("PATRIMONIO");
            builder.HasKey(p => p.NroTombo);
            builder.Property(p => p.NroTombo).HasColumnName("NRO_TOMBO");
            builder.Property(p => p.Nome).IsRequired().HasColumnName("NOME");
            builder.Property(p => p.Descricao).HasColumnName("DESCRICAO");

            builder.HasOne(a => a.Marca).WithOne();
            builder.Property(p => p.MarcaId).IsRequired().HasColumnName("MARCA_ID");
        }
    }
}