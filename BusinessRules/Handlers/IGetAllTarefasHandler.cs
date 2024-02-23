using Graph.BussinessRules.Response;

namespace Graph.BussinessRules.Handlers;

public interface IGetAllTarefasHandler
{
    TarefasResponse Execute();
}