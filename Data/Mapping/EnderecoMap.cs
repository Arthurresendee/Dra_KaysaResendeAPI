using drakaysa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace drakaysa.Data.Mapping
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(e => e.CEP)
                .HasColumnName("CEP")
                .HasColumnType("nvarchar")
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(e => e.Bairro)
                .HasColumnName("Bairro")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Estado)
                .HasColumnName("Estado")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Cidade)
                .HasColumnName("Cidade")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Rua)
                .HasColumnName("Rua")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Numero)
                .HasColumnName("Numero")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("nvarchar")
                .HasMaxLength(500)
                .IsRequired();

            builder.HasIndex(e => e.CEP, "IX_Endereco_CEP");

        }
    }
}
