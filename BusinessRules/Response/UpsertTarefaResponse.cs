using FluentValidation.Results;

namespace Graph.BussinessRules.Response;

public class UpsertTarefaResponse
{
    public UpsertTarefaResponsePayload Payload { get; set; }
    public List<ValidationFailure> Errors { get; set; }
}

public class UpsertTarefaResponsePayload
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public bool Feito { get; set; }
}