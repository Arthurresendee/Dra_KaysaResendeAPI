using System.ComponentModel.DataAnnotations.Schema;

namespace DRAKaysaResende.Models
{
    public class Endereco
    {

        public int Id { get; set; }
        public string? CEP {get;set;}
        public string? Pais { get; set; }
        public string? Estado { get; set; }
        public string? Cidade { get; set; }
        public string? Rua { get; set; }
        public string? Numero { get; set; }

        public Dentista? Dentista { get; set;}
        public Paciente? Paciente { get; set;}
    }
    
}
