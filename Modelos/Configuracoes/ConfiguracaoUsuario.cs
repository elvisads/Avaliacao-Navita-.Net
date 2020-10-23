using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Navita.Avaliacao.Modelos.Configuracoes
{
    public class ConfiguracaoUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");
            builder.HasKey(p => p.UsuarioId);
            builder.Property(p => p.UsuarioId).HasColumnName("USUARIO_ID");
            builder.Property(p => p.Nome).IsRequired().HasColumnName("NOME");
            builder.Property(p => p.Email).IsRequired().HasColumnName("EMAIL");
            builder.Property(p => p.Senha).IsRequired().HasColumnName("SENHA");
        }
    }
}