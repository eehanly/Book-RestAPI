using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSqlite<BookContext>("Data Source=BooksEntityFramework.db");


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "WebAPI", Version = "v1"});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
}

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
