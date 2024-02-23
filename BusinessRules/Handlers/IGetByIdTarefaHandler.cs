using Graph.BussinessRules.Request;
using Graph.BussinessRules.Response;

namespace Graph.BussinessRules.Handlers;

public interface IGetByIdTarefaHandler
{
    TarefaResponse Execute(GetByIdTarefaRequest request);
}