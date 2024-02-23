using FluentValidation;
using FluentValidation.Results;
using Graph.BussinessRules.Request;

namespace Graph.BussinessRules.Validators;

public class TarefaValidator : AbstractValidator<UpsertTarefaRequest>, ITarefaValidator
{
    public TarefaValidator()
    {
        RuleFor(t => t.Nome)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3)
            .MaximumLength(20)
            .WithName("Nome");
    }
}