using drakaysa.Data;
using drakaysa.Models;
using FluentValidation;

namespace drakaysa.Services.Validators
{
    public class CardValidator : AbstractValidator<Card>
    {
        private readonly DataContext _context;

        public CardValidator(DataContext dataContext)
        {
            _context = dataContext;

            RuleFor(c => c.Titulo)
                .NotEmpty().WithMessage("O Título é obrigatório.")
                .MaximumLength(150).WithMessage("O Título deve ter no máximo 150 caracteres.");

            RuleFor(c => c.Texto)
                .NotEmpty().WithMessage("O Texto é obrigatório.")
                .MaximumLength(1000).WithMessage("O Texto deve ter no máximo 1000 caracteres.");

            RuleFor(c => c.TopicoId)
                .NotEmpty().WithMessage("O Id do Tópico é obrigatório.")
                .GreaterThan(0).WithMessage("O Id do Tópico deve ser maior que 0.")
                .Must(TopicoExists).WithMessage("O Tópico associado não existe.");
        }

        private bool TopicoExists(int topicoId)
        {
            return _context.Topicos.Any(t => t.Id == topicoId);
        }
    }
}
