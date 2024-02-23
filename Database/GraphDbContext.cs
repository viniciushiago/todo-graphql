using Graph.Database.Domain;
using Microsoft.EntityFrameworkCore;

namespace Graph.Database;

public class GraphDbContext : DbContext
{
    public GraphDbContext(DbContextOptions<GraphDbContext> options) : base(options)
    {
    }
    public DbSet<Tarefa> Tarefa { get; set; }

}