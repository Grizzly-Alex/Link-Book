using Link.API.Utilities;
using Link.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Link.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAllAppServices();
builder.Services.AddAppDb(builder.Configuration.GetConnectionString("LinkDbConnection"));



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ApplyMigrations();//add logger
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<ExceptionHandler>();
app.MapControllers();
app.Run();
