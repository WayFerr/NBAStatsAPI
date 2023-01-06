using Microsoft.EntityFrameworkCore;
using NBAStatsAPI.Dominio.Interface;
using NBAStatsAPI.Dominio.Model;
using NBAStatsAPI.Dominio.ViewModel;
using NBAStatsAPI.Infra;
using NBAStatsAPI.Infra.Repositorio;
using NBAStatsAPI.Servicos.Interface;
using NBAStatsAPI.Servicos.Servicos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<NBAStatsAPIContext>(options => 
options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddScoped<IJogadorRepository, JogadorRepository>();
builder.Services.AddScoped<IPosicaoRepository, PosicaoRepository>();
builder.Services.AddScoped<ITimeRepository, TimeRepository>();

builder.Services.AddScoped<IJogadorServico, JogadorServico>();
builder.Services.AddScoped<IPosicaoServico, PosicaoServico>();
builder.Services.AddScoped<ITimeServico, TimeServico>();

builder.Services.AddAutoMapper(mapper =>
{
    mapper.CreateMap<JogadorViewModel, Jogador>().ReverseMap();
    mapper.CreateMap<PosicaoViewModel, Posicao>().ReverseMap();
    mapper.CreateMap<TimeViewModel, Time>().ReverseMap();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
