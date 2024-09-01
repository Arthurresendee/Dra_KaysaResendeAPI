using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DRAKaysaResende.Models
{
    public class Endereco
    {

        public int Id { get; set; }
        public string? CEP {get;set;}
        public string? Rua { get; set; }
        public int? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
    }
}
