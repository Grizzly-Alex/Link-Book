using Link.API.Utilities;
using Link.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppDb(builder.Configuration["Data:ConnectionString:DefaultConnection"]);
builder.Services.AddAllAppServices();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();    
}

app.Services.ApplyMigrations();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<ExceptionHandler>();
app.MapControllers();
app.Run();
