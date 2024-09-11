using DRAKaysaResende.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRAKaysaResende.Data.Mapping
{
    public class DentistaMap : IEntityTypeConfiguration<Dentista>
    {
        public void Configure(EntityTypeBuilder<Dentista> builder)
        {
            builder.ToTable("Dentistas");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("nvarchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.SobreNome)
                .HasColumnName("SobreNome")
                .HasColumnType("nvarchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Idade)
                .HasColumnName("Idade")
                .HasColumnType("INT")
                .IsRequired(false);

            builder.Property(x => x.CPF)
                .HasColumnName("CPF")
                .HasColumnType("nvarchar")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x => x.DataDeNascimento)
                .HasColumnName("DataDeNascimento")
                .HasColumnType("Date");

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.NumeroDeTelefone)
                .HasColumnName("NumeroDeTelefone")
                .HasColumnType("nvarchar")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(x => x.Especializacao)
                .HasColumnName("Especialização")
                .HasColumnType("TEXT")
                .IsRequired();

            builder.Property(x => x.NumeroDeRegistro)
                .HasColumnName("NumeroDeRegistro")
                .HasColumnType("nvarchar")
                .HasMaxLength(9)
                .IsRequired();

            builder.Property(x => x.IdEndereco)
                .HasColumnName("IdEndereco")
                .HasColumnType("INT")
                .IsRequired();

            builder.HasIndex(x => x.CPF, "IX_dentista_CPF")
                .IsUnique();

            builder.HasIndex(x => x.Nome, "IX_dentista_Nome");

            builder.HasOne(x => x.Endereco)
            .WithMany()
            .HasForeignKey(x => x.IdEndereco)
            .IsRequired();

            builder.HasMany(d => d.Pacientes)
            .WithOne(p => p.Dentista)
            .HasForeignKey(p => p.IdDentista)
            .IsRequired();
        }
    }
}
