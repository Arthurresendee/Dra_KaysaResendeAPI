using drakaysa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace drakaysa.Data.Mapping
{
    public class UsuarioDoSistemaMap : IEntityTypeConfiguration<UsuarioDoSistema>
    {
        public void Configure(EntityTypeBuilder<UsuarioDoSistema> builder)
        {
            builder.ToTable("UsuariosDoSistema");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(e => e.TipoDeUsuario)
                .HasColumnName("TipoDeUsuario")
                .HasColumnType("INT")
                .IsRequired(false);

            builder.Property(e => e.AcessoDeUsuario)
                .HasColumnName("AcessoDeUsuario")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Senha)
                .HasColumnName("Senha")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.NomeCompleto)
                .HasColumnName("NomeCompleto")
                .HasColumnType("nvarchar")
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(e => e.TipoDeSexo)
                .HasColumnName("TipoDeSexo")
                .HasColumnType("INT")
                .IsRequired(false);

            builder.HasIndex(e => e.AcessoDeUsuario, "IX_UsuarioDoSistema_AcessoDeUsuario")
                .IsUnique();
        }
    }
}