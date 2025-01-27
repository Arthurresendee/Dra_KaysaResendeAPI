using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace drakaysa.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Texto { get; set; } = string.Empty;
        public int TopicoId { get; set; }
        [JsonIgnore]
        public Topico? Topico { get; set; }
    }
}
