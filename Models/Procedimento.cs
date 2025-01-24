using DRAKaysa.Models.Enums;

namespace DRAKaysa.Models
{
    public class Procedimento
    {
        public Procedimento(){}

        public int Id { get; set; }
        public string Titulo { get; set; }
        public TipoDeProcedimentoEnum TipoDeProcedimento { get; set; }
        public string Descricao { get; set; }
        public ICollection<PacienteProcedimento> PacienteProcedimentos { get; set; }
    }
}
