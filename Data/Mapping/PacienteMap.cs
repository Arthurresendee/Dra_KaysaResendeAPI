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
                .UseIdentityColumn(1,1);

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.SobreNome)
                .HasColumnName("SobreNome")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();


            builder.Property(x => x.Idade)
                .HasColumnName("Idade")
                .HasColumnType("INT")
                .HasDefaultValue(18);

            builder.Property(x => x.CPF)
                .HasColumnName("CPF")
                .HasColumnType("nvarchar")
                .HasMaxLength(11)
                .HasDefaultValue("00000000000")
                .IsRequired(false);

            builder.Property(x => x.DataDeAniversario)
                .HasColumnName("DataDeAniversario")
                .HasColumnType("SMALLDATETIME")
                .IsRequired(false);

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("nvarchar")
                .HasMaxLength(5)
                .IsRequired(false);

            builder.Property(x => x.NumeroDeTelefone)
                .HasColumnName("NumeroDeTelefone")
                .HasColumnType("nvarchar")
                .HasMaxLength(15)
                .IsRequired(false);

            builder.HasOne(x => x.Endereco)
                .WithOne(x => x.Paciente)
                .HasForeignKey<Paciente>(x => x.IdEndereco)
                .IsRequired();
        }
    }
}
