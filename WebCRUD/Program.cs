using Microsoft.EntityFrameworkCore;
using WebCRUD;
using WebCRUDCore.cs.Implementation;
using WebCRUDCore.cs.Interfaces;
using WebCRUDInfraStructure.cs.DataDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connection = builder.Configuration.GetConnectionString("WebDB");

builder.Services.AddDbContext<WebDbContext>(Options=>Options.UseSqlServer(connection));

builder.Services.AddScoped<IAddition, Addition>();

builder.Services.AddScoped<ICustomerCreator, CustomerCreator>();
builder.Services.AddScoped<IExcelCreator, ExcelCreator>();
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
