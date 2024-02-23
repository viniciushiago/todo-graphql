using Graph.Database.Domain;

namespace Graph.Database.Repositories;

public interface ITarefaRepository
{
    IQueryable<Tarefa> ObterTodos();
    Tarefa ObterPorId(long id);
    Tarefa Salvar(Tarefa tarefa);
}