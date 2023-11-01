using Shared.Context;
using Shared.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IGeneralRepository, GeneralRepository<ApplicationDbContext>>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();