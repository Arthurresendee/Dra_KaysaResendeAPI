using DRAKaysaResende.Models;
using Microsoft.JSInterop.Infrastructure;

namespace DRAKaysa.Services.Validators
{
    public class DentistaValidator
    {
        public DentistaValidator()
        {

        }

        public void Validate(Dentista dentista)
        {
            if (dentista.CPF.Length != 11)
            {
                throw new ArgumentException("cpf inválido");
            }

        }

    }
}
