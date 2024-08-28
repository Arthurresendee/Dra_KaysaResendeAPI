using DRAKaysaResende.Models;

namespace DRAKaysa.Services.Validators
{
    public class EnderecoValidator
    {
        public EnderecoValidator()
        {

        }

        public void Validate(Endereco endereco)
        {
            if (endereco.CEP.Length != 8)
            {
                throw new ArgumentException("O CEP deve conter exatamente 8 caracteres.");
            }
        }
    }
}
