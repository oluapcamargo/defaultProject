using Microsoft.EntityFrameworkCore;

namespace V1.DefaultProject.Persistence.ModelConfiguration.Table.Usuarios
{
    public class HomeConfig : IEntityTypeConfiguration<Domain.Entities.Home.Home>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Entities.Home.Home> builder)
        {
            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Codigo).HasColumnName("CD_HOME");
            builder.Property(x => x.DataCriacao).HasColumnName("DT_REGISTRO").HasDefaultValueSql("getdate()");
            builder.Property(x => x.Desenvolvedor).HasColumnName("TX_NOME_DESENVOLVEDOR");
            builder.Property(x => x.DataDesativacao).HasColumnName("DT_DESATIVACAO");    
        }
    }
}
