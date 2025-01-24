using DRAKaysa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRAKaysa.Data.Mapping
{
    public class TopicoMap : IEntityTypeConfiguration<Topico>
    {
        public void Configure(EntityTypeBuilder<Topico> builder)
        {
            builder.ToTable("Topicos");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(t => t.TituloTopico)
                .HasMaxLength(200).IsRequired();

            builder.HasMany(t => t.Cards)
                   .WithOne(c => c.Topico)
                   .HasForeignKey(c => c.TopicoId);
        }
    }
}
