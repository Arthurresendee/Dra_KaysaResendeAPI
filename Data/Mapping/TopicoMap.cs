using drakaysa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace drakaysa.Data.Mapping
{
    public class TopicoMap : IEntityTypeConfiguration<Topico>
    {
        public void Configure(EntityTypeBuilder<Topico> builder)
        {
            builder.ToTable("Topicos");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.TituloTopico)
                .HasMaxLength(200).IsRequired();

            builder.HasMany(t => t.Cards)
                   .WithOne(c => c.Topico)
                   .HasForeignKey(c => c.TopicoId);
        }
    }
}
