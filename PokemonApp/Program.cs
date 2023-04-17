using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using PokemonApp.Data;
using PokemonApp.GraphQL;
using PokemonApp.Repository.Interface;
using PokemonApp.Repository.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationdbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Constr")));

builder.Services.AddTransient<IPokemonRepository, PokemonRepository>();
builder.Services.AddTransient<ITypetable, TypeTabledata>();
builder.Services.AddTransient<PokemonType>();
builder.Services.AddTransient<PokemonQuery>();
builder.Services.AddTransient<ISchema, PokemonSchema>();



builder.Services.AddTransient<PokemonMutation>();
builder.Services.AddTransient<PokemonInput>();

// Initializeing the GraphQL

builder.Services.AddGraphQL(opt => opt.EnableMetrics = false).AddSystemTextJson();

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
app.UseGraphQLAltair();
app.UseGraphQL<ISchema>();

app.Run();
