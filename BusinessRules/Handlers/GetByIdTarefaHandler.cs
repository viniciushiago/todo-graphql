using Graph.BussinessRules.Request;
using Graph.BussinessRules.Response;
using Graph.Database.Repositories;

namespace Graph.BussinessRules.Handlers;

public class GetByIdTarefaHandler : IGetByIdTarefaHandler
{
    private readonly ITarefaRepository _repository;
    
    public GetByIdTarefaHandler(ITarefaRepository repository)
    {
        _repository = repository;
    }
    public TarefaResponse Execute(GetByIdTarefaRequest request)
    {
        var tarefa = _repository.ObterPorId(request.Id);
        if (tarefa == null)
        {
            throw new Exception("Tarefa não encontrada");
        }

        return new TarefaResponse()
        {
            Payload = new TarefaResponseItem()
            {
                Id = tarefa.Id.Value,
                Nome = tarefa.Nome,
                Feito = tarefa.Feito
            }
        };
    }
}