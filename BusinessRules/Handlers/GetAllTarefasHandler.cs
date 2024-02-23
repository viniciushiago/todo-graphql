using Graph.BussinessRules.Response;
using Graph.Database.Repositories;

namespace Graph.BussinessRules.Handlers;

public class GetAllTarefasHandler : IGetAllTarefasHandler
{
    private readonly ITarefaRepository _repository;
    
    public GetAllTarefasHandler(ITarefaRepository repository)
    {
        _repository = repository;
    }
    public TarefasResponse Execute()
    {
        var tarefas = _repository.ObterTodos()
            .Select(x => new TarefaResponseItem()
            {
                Id = x.Id.Value,
                Nome = x.Nome,
                Feito = x.Feito
            }).ToList();

        return new TarefasResponse()
        {
            Payload = tarefas
        };
    }
}