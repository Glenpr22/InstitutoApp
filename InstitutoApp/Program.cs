using Academico.API.Extensions;
using Academico.Common.Interfaces;
using Academico.Repository;
using Academico.Services;


var builder = WebApplication.CreateBuilder(args);


//registro contenedor de inyeccion de dependencias total del aplicativo
//AddAplicationServices
builder.Services.AddAplicationServices(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
