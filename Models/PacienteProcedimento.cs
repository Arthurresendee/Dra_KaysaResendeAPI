

namespace drakaysa.Models
{
    public class PacienteProcedimento
    {
        public int IdPaciente { get; set; }
        public Paciente Paciente { get; set; }
        public int IdProcedimento { get; set; }
        public Procedimento Procedimento { get; set; }
        public DateTime DataProcedimento { get; set; }
        public bool ProcedimentoRealizado { get; set; }
    }
}
