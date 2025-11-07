using Microsoft.EntityFrameworkCore;
using SimuladorAcademia.Aplicacao.Interfaces;
using SimuladorAcademia.Aplicacao.Servicos;
using SimuladorAcademia.Dominio.Contratos;
using SimuladorAcademia.Infraestrutura.Dados;
using SimuladorAcademia.Infraestrutura.Repositorios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SimuladorAcademiaDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("SimuladorAcademia.Infraestrutura")));


builder.Services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
builder.Services.AddScoped<IAulaRepositorio, AulaRepositorio>();
builder.Services.AddScoped<IReservaRepositorio, ReservaRepositorio>();
builder.Services.AddScoped<ITipoDePlanoRepositorio, TipoPlanoRepositorio>();
builder.Services.AddScoped<ITipoDeAulaRepositorio, TipoAulaRepositorio>();

builder.Services.AddScoped<IAlunoServico, AlunoServico>();
builder.Services.AddScoped<IAulaServico, AulaServico>();
builder.Services.AddScoped<IReservaServico, ReservaServico>();
builder.Services.AddScoped<ITipoDePlanoServico, TipoDePlanoServico>();
builder.Services.AddScoped<ITipoDeAulaServico, TipoDeAulaServico>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SimuladorAcademiaDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
