using DRAKaysaResende.Data;
using DRAKaysaResende.Models;
using FluentValidation;

public class EnderecoValidator : AbstractValidator<Endereco>
{
    private readonly DataContext _context;

    public EnderecoValidator(DataContext context)
    {
        _context = context;

        RuleFor(e => e.CEP)
            .NotEmpty().WithMessage("O CEP é obrigatório.")
            .Length(8).WithMessage("O CEP deve ter 8 caracteres.");

        RuleFor(e => e.Bairro)
            .NotEmpty().WithMessage("O Bairro é obrigatório.")
            .MaximumLength(50).WithMessage("O Bairro deve ter no máximo 50 caracteres.");

        RuleFor(e => e.Estado)
            .NotEmpty().WithMessage("O Estado é obrigatório.")
            .MaximumLength(50).WithMessage("O Estado deve ter no máximo 50 caracteres.");

        RuleFor(e => e.Cidade)
            .NotEmpty().WithMessage("A Cidade é obrigatória.")
            .MaximumLength(50).WithMessage("A Cidade deve ter no máximo 50 caracteres.");

        RuleFor(e => e.Rua)
            .NotEmpty().WithMessage("A Rua é obrigatória.")
            .MaximumLength(100).WithMessage("A Rua deve ter no máximo 100 caracteres.");

        RuleFor(e => e.Numero)
            .NotEmpty().WithMessage("O Número é obrigatório.")
            .Must((endereco, numero) => BeUnique(endereco.CEP, numero))
            .WithMessage("Já existe um endereço com o mesmo CEP e Número.");
    }

    private bool BeUnique(string cep, string numero)
    {
        return !_context.Enderecos.Any(e => e.CEP == cep && e.Numero == numero);
    }
}
