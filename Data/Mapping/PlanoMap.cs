using drakaysa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace drakaysa.Data.Mapping
{
    public class PlanoMap : IEntityTypeConfiguration<Plano>
    {
        public void Configure(EntityTypeBuilder<Plano> builder)
        {
            builder.ToTable("Planos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Titulo)
                .HasColumnName("Titulo")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(x => x.TipoDePlano)
                .HasColumnName("TipoDePlano")
                .HasColumnType("INT")
                .HasDefaultValue(null)
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired(false);

            builder.Property(x => x.Coberturas)
                .HasColumnName("Coberturas")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(x => x.DataInicial)
                .HasColumnName("DataInicial")
                .HasColumnType("DATETIME")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.Property(x => x.DataFinal)
                .HasColumnName("DataFinal")
                .HasColumnType("DATETIME")
                .HasDefaultValue(null)
                .IsRequired();
        }
    }
}
