using Graph.BussinessRules.Request;
using Graph.BussinessRules.Response;
using Graph.BussinessRules.Validators;
using Graph.Database.Domain;
using Graph.Database.Repositories;

namespace Graph.BussinessRules.Handlers;

public class UpsertTarefaHandler : IUpsertTarefaHandler
{
    private readonly ITarefaRepository _repository;
    private readonly ITarefaValidator _validator;
    
    public UpsertTarefaHandler(ITarefaRepository repository, ITarefaValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public UpsertTarefaResponse Execute(UpsertTarefaRequest request)
    {
        var validatorResult = _validator.Validate(request);
        if (!validatorResult.IsValid)
        {
            return new UpsertTarefaResponse()
            {
                Errors = validatorResult.Errors
            };
        }

        Tarefa entidade;
        if (request.Id.HasValue)
        {
            entidade = _repository.ObterPorId(request.Id.Value);
            if (entidade == null)
            {
                throw new Exception("Tarefa não encontrada");
            }
        }
        else
        {
            entidade = new Tarefa();
        }

        entidade.Nome = request.Nome;
        entidade.Feito = request.Feito;

        _repository.Salvar(entidade);

        return new UpsertTarefaResponse()
        {
            Payload = new UpsertTarefaResponsePayload()
            {
                Id = entidade.Id.Value,
                Nome = entidade.Nome,
                Feito = entidade.Feito
            }
        };
    }
}