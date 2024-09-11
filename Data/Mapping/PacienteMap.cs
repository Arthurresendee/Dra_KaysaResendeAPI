using DRAKaysaResende.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRAKaysaResende.Data.Mapping
{
    public class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Pacientes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1);

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Sexo)
                .HasColumnName("Sexo")
                .HasColumnType("int") // Assuming enum is stored as int
                .IsRequired();

            builder.Property(x => x.DataDeNascimento)
                .HasColumnName("DataDeNascimento")
                .HasColumnType("datetime")
                .IsRequired(false);

            builder.Property(x => x.CPF)
                .HasColumnName("CPF")
                .HasColumnType("nvarchar")
                .HasMaxLength(11)
                .HasDefaultValue("00000000000")
                .IsRequired(false);

            builder.Property(x => x.RG)
                .HasColumnName("RG")
                .HasColumnType("nvarchar")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.NumeroDeTelefone)
                .HasColumnName("NumeroDeTelefone")
                .HasColumnType("nvarchar")
                .HasMaxLength(15)
                .IsRequired(false);

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.Telefone)
                .HasColumnName("Telefone")
                .HasColumnType("nvarchar")
                .HasMaxLength(15)
                .IsRequired(false);

            builder.Property(x => x.Whatsapp)
                .HasColumnName("Whatsapp")
                .HasColumnType("nvarchar")
                .HasMaxLength(15)
                .IsRequired(false);

            builder.HasOne(x => x.Dentista)
                .WithMany(d => d.Pacientes)
                .HasForeignKey(x => x.IdDentista)
                .IsRequired();

            builder.HasMany(x => x.PacientePlanos)
                .WithOne(pp => pp.Paciente)
                .HasForeignKey(pp => pp.IdPaciente)
                .IsRequired();

            builder.HasMany(x => x.PacienteProcedimentos)
                .WithOne(pp => pp.Paciente)
                .HasForeignKey(pp => pp.IdPaciente)
                .IsRequired();
        }
    }
}
