using Graph.Database.Domain;

namespace Graph.Database.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly GraphDbContext _context;

    public TarefaRepository(GraphDbContext context)
    {
        _context = context;
    }
    public IQueryable<Tarefa> ObterTodos()
    {
        return _context.Tarefa.AsQueryable();
    }

    public Tarefa ObterPorId(long id)
    {
        return _context.Tarefa.FirstOrDefault(x => x.Id == id);
    }

    public Tarefa Salvar(Tarefa tarefa)
    {
        if (!tarefa.Id.HasValue)
        {
            _context.Tarefa.Add(tarefa);
        }
        
        _context.SaveChanges();

        return tarefa;
    }
}