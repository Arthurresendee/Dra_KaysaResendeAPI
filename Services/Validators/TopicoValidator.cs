using drakaysa.Models;
using FluentValidation;

namespace drakaysa.Services.Validators
{
    public class TopicoValidator : AbstractValidator<Topico>
    {
        public TopicoValidator()
        {
            RuleFor(t => t.TituloTopico)
                .NotEmpty().WithMessage("O Título do Tópico é obrigatório.")
                .MaximumLength(150).WithMessage("O Título do Tópico deve ter no máximo 150 caracteres.");
        }
    }
}
