 using DRAKaysa.Models;

namespace DRAKaysa.Models
{
    public class Topico
    {
        public int Id { get; set; }
        public string TituloTopico { get; set; } = string.Empty;
        public ICollection<Card> Cards { get; set; } = new List<Card>();
    }
}
