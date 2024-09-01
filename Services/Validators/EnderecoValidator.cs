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
            if (string.IsNullOrEmpty(endereco.CEP) || endereco.CEP.Length != 8 || !endereco.CEP.All(char.IsDigit))
            {
                throw new ArgumentException("O CEP deve conter exatamente 8 caracteres numéricos.");
            }
        }

        public void GerarDescricao(Endereco endereco)
        {
            endereco.Descricao = $"Rua: {endereco.Rua}, nº: {endereco.Numero}, Estado: {endereco.Estado}, CEP: {endereco.CEP}";
        }
    }
}
