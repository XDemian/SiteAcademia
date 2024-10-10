using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteAcademia.Models;

namespace SiteAcademia.Data.Map
{
    public class TreinoMap : IEntityTypeConfiguration<TreinoModel>
    {
        public void Configure(EntityTypeBuilder<TreinoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property( x => x.ClienteId); // Verificar depois se aqui vai ficar referenciado o cliente
            builder.Property(x => x.Exercicios).HasMaxLength(1000);
            builder.Property(x => x.Data);
            builder.Property(x => x.Observacoes);
        }
    }
}

