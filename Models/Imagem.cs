namespace drakaysa.Models
{
    public class Imagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public byte[] ImagemBytes { get; set; }
    }
}
