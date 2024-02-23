using FluentValidation;
using Graph.BussinessRules.Request;

namespace Graph.BussinessRules.Validators;

public interface ITarefaValidator : IValidator<UpsertTarefaRequest>
{
    
}