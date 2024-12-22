using AccesoDatos;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSqlServer<BancoContext>("Data Source=LEIVAAA-P\\LOCAL2016;Database=BCCR;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
//builder.Services.AddSqlServer<BancoContext>("SERVER=docker_sqlserver;Initial Catalog=bccr;User Id=sa;Password=myPassword1!;Encrypt=False");
Trace.WriteLine("Creando migración");
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    Trace.WriteLine("Creando migración");
    var services = scope.ServiceProvider;

    
    var context = services.GetRequiredService<BancoContext>();
    context.Database.Migrate();
    
}

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{*/
app.UseSwagger();
    app.UseSwaggerUI();
//}



app.UseAuthorization();

app.MapControllers();



app.Run();
