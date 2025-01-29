using drakaysa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace drakaysa.Data.Mapping
{
    public class PacienteProcedimentoMap : IEntityTypeConfiguration<PacienteProcedimento>
    {
        public void Configure(EntityTypeBuilder<PacienteProcedimento> builder)
        {
            builder.ToTable("PacienteProcedimentos");

            builder.HasKey(x => new { x.IdPaciente, x.IdProcedimento });

            builder.Property(x => x.IdPaciente)
                .IsRequired();

            builder.Property(x => x.IdProcedimento)
                .IsRequired();

            builder.Property(x => x.DataProcedimento)
                .IsRequired()
                .HasColumnName("DataProcedimento")
                .HasColumnType("SMALLDATETIME")
                .IsRequired();

            builder.HasIndex(x => x.ProcedimentoRealizado, "IX_PacienteProcedimento_ProcedimentoRealizado")
                .IsUnique();

            builder.HasOne(p => p.Paciente)
                .WithMany(p => p.PacienteProcedimentos)
                .HasForeignKey(p => p.IdPaciente)
                .OnDelete(DeleteBehavior.Restrict); // Restrict especifica que ao excluir o pai, o filho não será excluído.

            builder.HasOne(p => p.Procedimento)
                .WithMany(p => p.PacienteProcedimentos)
                .HasForeignKey(p => p.IdProcedimento)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
