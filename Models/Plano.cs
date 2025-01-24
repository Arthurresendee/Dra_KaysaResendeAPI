using DRAKaysa.Models.Enums;

namespace DRAKaysa.Models
{
    public class Plano
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public TipoDePlanoEnum? TipoDePlano { get; set; }
        public string Descricao { get; set; }
        public string Coberturas { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public ICollection<PacientePlano> PacientePlanos { get; set; }
    }
}
