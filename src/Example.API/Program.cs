using Example.Application.CidadeService.Service;
using Example.Application.PessoaService.Services;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICidadeService, CidadeService>();
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddDbContext<ExampleContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ExampleContext>();
    dataContext.Database.Migrate();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

