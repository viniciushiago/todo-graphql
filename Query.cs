using Graph.BussinessRules.Handlers;
using Graph.BussinessRules.Request;
using Graph.BussinessRules.Response;
using Microsoft.AspNetCore.Cors;

namespace Graph.Graph;

[DisableCors]
public class Query
{
    [DisableCors]
    public TarefasResponse GetTarefas([Service] IGetAllTarefasHandler handler)
    {
        return handler.Execute();
    }
    [DisableCors]
    public TarefaResponse GetTarefa([Service] IGetByIdTarefaHandler handler, GetByIdTarefaRequest request)
    {
        return handler.Execute(request);
    }
}