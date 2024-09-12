
using DRAKaysa.Models.Enums;
using System.Runtime.Serialization;

namespace DRAKaysaResende.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public TipoDeSexoEnum? Sexo { get; set; }
        public DateTime? DataDeNascimento { get; set; }
        public string? CPF { get; set; }
        public string? RG { get; set; }
        public string? NumeroDeTelefone { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Whatsapp { get; set; }
        public int? IdDentista { get; set; }
        public Dentista? Dentista { get; set; }
        public int? IdEndereco { get; set; }
        public Endereco? Endereco { get; set; }
        public ICollection<PacientePlano>? PacientePlanos { get; set; }
        public ICollection<PacienteProcedimento>? PacienteProcedimentos { get; set; }
    }
}
