using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteAcademia.Models;

namespace SiteAcademia.Data.Map
{
    public class PersonalMap : IEntityTypeConfiguration<PersonalModel>
    {
        public void Configure(EntityTypeBuilder<PersonalModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Contato).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ImagemUrl).IsRequired();
        }
    }
}
