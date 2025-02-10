namespace drakaysa.Models
{
    public class Topico
    {
        public int Id { get; set; }
        public string TituloTopico { get; set; } = string.Empty;
        public IList<Card> Cards { get; set; } = new List<Card>();
    }
}
