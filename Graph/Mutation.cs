using Graph.BussinessRules.Handlers;
using Graph.BussinessRules.Request;
using Graph.BussinessRules.Response;

namespace Graph.Graph;

public class Mutation
{
    public UpsertTarefaResponse UpsertTarefa([Service] IUpsertTarefaHandler handler, UpsertTarefaRequest request)
    {
        UpsertTarefaResponse entidade = handler.Execute(request);
        return entidade;
    }
}