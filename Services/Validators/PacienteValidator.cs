using drakaysa.Data;
using drakaysa.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace drakaysa.Services.Validators
{
    public class PacienteValidator : AbstractValidator<Paciente>
    {
        private readonly DataContext _context;
        public PacienteValidator(DataContext context)
        {
            _context = context;

            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O Nome é obrigatório.")
                .MaximumLength(100).WithMessage("O Nome deve ter no máximo 100 caracteres.");

            RuleFor(p => p.Sexo)
                .IsInEnum().WithMessage("O Sexo é inválido.");

            RuleFor(p => p.DataDeNascimento)
                .NotEmpty().WithMessage("A Data de Nascimento é obrigatória.")
                .LessThan(DateTime.Now).WithMessage("A Data de Nascimento deve ser no passado.");

            RuleFor(p => p.CPF)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Matches(@"^\d{11}$").WithMessage("O CPF deve conter apenas números.")
                .Length(11).WithMessage("O CPF deve ter 11 caracteres.")
                .Must(BeUnique).WithMessage("Já existe um dentista cadastrado com esse CPF");

            RuleFor(p => p.RG)
                .MaximumLength(20).WithMessage("O RG deve ter no máximo 20 caracteres.");

            RuleFor(p => p.NumeroDeTelefone)
                .MaximumLength(15).WithMessage("O Número de Telefone deve ter no máximo 15 caracteres.");

            RuleFor(p => p.Email)
                .EmailAddress().WithMessage("O Email é inválido.")
                .MaximumLength(100).WithMessage("O Email deve ter no máximo 100 caracteres.");

            RuleFor(p => p.Telefone)
                .MaximumLength(15).WithMessage("O Telefone deve ter no máximo 15 caracteres.");

            RuleFor(p => p.Whatsapp)
                .MaximumLength(15).WithMessage("O Whatsapp deve ter no máximo 15 caracteres.");

            RuleFor(p => p.IdDentista)
                .GreaterThan(0).When(p => p.IdDentista.HasValue).WithMessage("O IdDentista deve ser maior que zero.");

            RuleFor(p => p.IdEndereco)
                .GreaterThan(0).When(p => p.IdEndereco.HasValue).WithMessage("O IdEndereco deve ser maior que zero.");
        }

        private bool BeUnique(string cpf)
        {
            return !_context.Dentistas.Any(e => e.CPF == cpf);
        }
    }
}
