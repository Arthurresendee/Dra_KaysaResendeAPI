namespace drakaysa.Models
{
    public class PacientePlano
    {
        public int IdPaciente { get; set; }
        public Paciente Paciente { get; set; }
        public int IdPlano { get; set; }
        public Plano Plano { get; set; }
        public bool PlanoAtivo { get; set; }

    }
}
