using szamonkeres_01._04.Models;
using szamonkeres_01._04.Repositories.Interfaces;
using szamonkeres_01._04.Repositories.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PeopleDbContext>();
builder.Services.AddScoped<IPersonInterface, PersonService>();
builder.Services.AddScoped<ICreditCardInterface, CreditCardService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
