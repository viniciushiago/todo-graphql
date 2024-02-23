using Graph.BussinessRules.Request;
using Graph.BussinessRules.Response;

namespace Graph.BussinessRules.Handlers;

public interface IUpsertTarefaHandler
{
    UpsertTarefaResponse Execute(UpsertTarefaRequest request);
}