namespace Graph.BussinessRules.Request;

public class UpsertTarefaRequest
{
    public long? Id { get; set; }
    public string Nome { get; set; }
    public bool Feito { get; set; }
}