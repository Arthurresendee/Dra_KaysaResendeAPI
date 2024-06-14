
using System.Runtime.Serialization;

namespace DRAKaysaResende.Models
{
    public class Paciente
    {
        public Paciente()
        {

        }
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? SobreNome { get; set; }
        public int? Idade { get; set; }
        public string? CPF { get; set; }
        public DateTime? DataDeAniversario { get; set; }
        public string? Email { get; set; }   
        public string? NumeroDeTelefone { get; set; }
        public int? IdEndereco { get; set; }
        public Endereco? Endereco { get; set; }
        public ICollection<PacientePlano> PacientePlanos { get; set; }
        public ICollection<PacienteProcedimento> PacienteProcedimentos { get; set; }
    }
}
