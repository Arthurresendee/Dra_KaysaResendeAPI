using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace DRAKaysaResende.Models
{
    public class Endereco
    {

        public int Id { get; set; }
        public string? CEP {get;set;}
        public string? Rua { get; set; }
        public string Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Descricao { get; set; } //Esse campo irá mostrar todos os anteriores como uma string. Para assim, ser selecionado no front para escolha de um endereco do dentista

        public override string ToString()
        {
            return $"Rua: {Rua}, nº: {Numero}, Bairro: {Bairro}, Cidade: {Cidade}, Estado: {Estado}, CEP: {CEP}";
        }

        public void GerarDescricao()
        {
            Descricao = ToString();
        }
    }

}
