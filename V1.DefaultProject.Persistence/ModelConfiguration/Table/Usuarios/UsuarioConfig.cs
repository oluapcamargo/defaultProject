using Microsoft.EntityFrameworkCore;

namespace V1.DefaultProject.Persistence.ModelConfiguration.Table.Usuarios
{
    public class UsuarioConfig : IEntityTypeConfiguration<Domain.Entities.Usuario>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Entities.Usuario> builder)
        {
            builder.HasKey(x => x.Codigo);
            builder.Property(x => x.Codigo).HasColumnName("CD_USUARIO");
            builder.Property(x => x.DataRegistro).HasColumnName("DT_REGISTRO").HasDefaultValueSql("getdate()");
            builder.Property(x => x.Nome).HasColumnName("TX_NOME");
            builder.Property(x => x.Email).HasColumnName("TX_EMAIL").HasColumnType("VARCHAR(50)");
            builder.Property(x => x.Documento).HasColumnName("TX_DOCUMENTO").HasColumnType("VARCHAR(200)");
        }
    }
}
