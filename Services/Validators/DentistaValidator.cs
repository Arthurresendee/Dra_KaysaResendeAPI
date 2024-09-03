using DRAKaysaResende.Models;
using FluentValidation;
using Microsoft.JSInterop.Infrastructure;

namespace DRAKaysa.Services.Validators
{
    public class DentistaValidator : AbstractValidator<Dentista>
    {
        public DentistaValidator()
        {
            RuleFor(p => p.Nome)
            .NotEmpty().WithMessage("O Nome é obrigatório.")
            .MaximumLength(100).WithMessage("O Nome deve ter no máximo 100 caracteres.");

            RuleFor(p => p.SobreNome)
                .NotEmpty().WithMessage("O Sobrenome é obrigatório.")
                .MaximumLength(100).WithMessage("O Sobrenome deve ter no máximo 100 caracteres.");

            RuleFor(p => p.CPF)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Length(11).WithMessage("O CPF deve ter 11 caracteres.")
                .Matches(@"^\d{11}$").WithMessage("O CPF deve conter apenas números.");

            RuleFor(p => p.DataDeNascimento)
                .NotEmpty().WithMessage("A Data de Nascimento é obrigatória.")
                .LessThan(DateTime.Now).WithMessage("A Data de Nascimento deve ser no passado.");

            RuleFor(p => p.Idade)
                .GreaterThan(0).WithMessage("A Idade deve ser maior que 0.")
                .LessThanOrEqualTo(120).WithMessage("A Idade deve ser menor ou igual a 120.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("O Email é obrigatório.")
                .EmailAddress().WithMessage("O Email deve ser válido.");

            RuleFor(p => p.NumeroDeTelefone)
                .NotEmpty().WithMessage("O Número de Telefone é obrigatório.")
                .Matches(@"^\d{10,11}$").WithMessage("O Número de Telefone deve ter 10 ou 11 dígitos.");

            RuleFor(p => p.NumeroDeRegistro)
                .NotEmpty().WithMessage("O Número de Registro é obrigatório.")
                .MaximumLength(20).WithMessage("O Número de Registro deve ter no máximo 20 caracteres.");

            RuleFor(p => p.Especializacao)
                .NotEmpty().WithMessage("A Especialização é obrigatória.")
                .MaximumLength(100).WithMessage("A Especialização deve ter no máximo 100 caracteres.");

            RuleFor(p => p.IdEndereco)
                .NotEmpty().WithMessage("O Endereco é obrigatório.")
                .GreaterThan(0).WithMessage("O Id do Endereço deve ser maior que 0.");
        }
    }
}
