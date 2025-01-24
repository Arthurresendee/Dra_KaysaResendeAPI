using DRAKaysa.Data;
using DRAKaysa.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.JSInterop.Infrastructure;

namespace DRAKaysa.Services.Validators
{
    public class DentistaValidator : AbstractValidator<Dentista>
    {
        private readonly DataContext _context;
        public DentistaValidator(DataContext dataContext)
        {
            _context = dataContext;

            RuleFor(p => p.Nome)
            .NotEmpty().WithMessage("O Nome é obrigatório.")
            .MaximumLength(100).WithMessage("O Nome deve ter no máximo 100 caracteres.");

            RuleFor(p => p.SobreNome)
                .NotEmpty().WithMessage("O Sobrenome é obrigatório.")
                .MaximumLength(100).WithMessage("O Sobrenome deve ter no máximo 100 caracteres.");

            RuleFor(p => p.CPF)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Matches(@"^\d{11}$").WithMessage("O CPF deve conter apenas números.")
                .Length(11).WithMessage("O CPF deve ter 11 caracteres.")
                .Must(BeUnique).WithMessage("Já existe um dentista cadastrado com esse CPF");

            RuleFor(p => p.DataDeNascimento)
                .NotEmpty().WithMessage("Data de Nascimento é obrigatória.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("O Email é obrigatório.")
                .EmailAddress().WithMessage("O Email deve ser válido.");

            RuleFor(p => p.NumeroDeTelefone)
                .NotEmpty().WithMessage("O Número de Telefone é obrigatório.")
                .Matches(@"^\d{10,11}$").WithMessage("O Celular deve ter 10 ou 11 dígitos.");

            RuleFor(p => p.NumeroDeRegistro)
                .NotEmpty().WithMessage("O Número de Registro é obrigatório.")
                .MaximumLength(20).WithMessage("O Número de Registro deve ter no máximo 9 caracteres.");

            RuleFor(p => p.Especializacao)
                .NotEmpty().WithMessage("A Especialização é obrigatória.")
                .MaximumLength(100).WithMessage("A Especialização deve ter no máximo 100 caracteres.");

            RuleFor(p => p.IdEndereco)
                .NotEmpty().WithMessage("O Endereco é obrigatório.")
                .GreaterThan(0).WithMessage("O Id do Endereço deve ser maior que 0.");
        }

        private bool BeUnique(string cpf)
        {
            return !_context.Dentistas.Any(e => e.CPF == cpf);
        }
    }
}
