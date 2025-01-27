using drakaysa.Models.Enums;
using drakaysa.Models.Enums;

namespace drakaysa.Models
{
    public class UsuarioDoSistema
    {
        public int Id { get; set; }
        public TipoDeUsuarioEnum? TipoDeUsuario { get; set; }
        public string AcessoDeUsuario { get; set; }
        public string Senha { get; set; }
        public string? NomeCompleto { get; set; }
        public TipoDeSexoEnum? TipoDeSexo { get; set; }

    }
}
