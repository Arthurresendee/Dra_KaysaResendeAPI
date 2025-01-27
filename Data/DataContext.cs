using drakaysa.Data.Mapping;
using drakaysa.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace drakaysa.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Dentista> Dentistas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Procedimento> Procedimentos { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<PacientePlano> PacientePlanos { get; set; }
        public DbSet<PacienteProcedimento> PacienteProcedimentos { get; set; }
        public DbSet<UsuarioDoSistema> UsuariosdoSistema { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Topico> Topicos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=db;Database=drakaysa;User ID=sa;Password=root; TrustServerCertificate=true");
            //optionsBuilder.UseSqlServer("Server=localhost;Database=drakaysa;User ID=sa;Password=SuaNovaSenhaForte123; TrustServerCertificate=true");
            //optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DentistaMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new PacienteMap());
            modelBuilder.ApplyConfiguration(new ProcedimentoMap());
            modelBuilder.ApplyConfiguration(new PlanoMap());
            modelBuilder.ApplyConfiguration(new PacientePlanoMap());
            modelBuilder.ApplyConfiguration(new PacienteProcedimentoMap());
            modelBuilder.ApplyConfiguration(new UsuarioDoSistemaMap());
            modelBuilder.ApplyConfiguration(new CardMap());
            modelBuilder.ApplyConfiguration(new TopicoMap());
        }
    }
}
