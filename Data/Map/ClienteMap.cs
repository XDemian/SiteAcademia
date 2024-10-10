using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteAcademia.Models;

namespace SiteAcademia.Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<ClienteModel>
    {
        public void Configure(EntityTypeBuilder<ClienteModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(255);
            builder.Property(x => x.Email).HasMaxLength(255);
            builder.Property(x => x.Senha).HasMaxLength(25);
            builder.Property(x => x.Altura).HasMaxLength(25);
            builder.Property(x => x.Peso).HasMaxLength(25);

        }
    }
}

