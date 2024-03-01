using Graph.BussinessRules.Handlers;
using Graph.BussinessRules.Validators;
using Graph.Database;
using Graph.Database.Repositories;
using Graph.Graph;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
builder.Services.AddScoped<IUpsertTarefaHandler, UpsertTarefaHandler>();
builder.Services.AddScoped<IGetAllTarefasHandler, GetAllTarefasHandler>();
builder.Services.AddScoped<IGetByIdTarefaHandler, GetByIdTarefaHandler>();
builder.Services.AddScoped<ITarefaValidator, TarefaValidator>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<GraphDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

var app = builder.Build();

app.MapGraphQL();

app.Run();