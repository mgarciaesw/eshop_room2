using Application;
using FastEndpoints.Swagger;
using FastEndpoints;
using Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();
builder.Services.AddAuthorization();

builder.Services.AddApplication();
builder.Services.AddPersistence();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseDefaultExceptionHandler();
app.UseFastEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
}

app.Run();