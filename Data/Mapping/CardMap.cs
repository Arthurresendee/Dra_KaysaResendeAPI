using drakaysa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace drakaysa.Data.Mapping
{
    public class CardMap : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("Cards");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Titulo)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Texto)
                .HasMaxLength(500);

            builder.HasOne(c => c.Topico)
                   .WithMany(t => t.Cards)
                   .HasForeignKey(c => c.TopicoId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(d => d.Id).IsUnique();
        }
    }
}
