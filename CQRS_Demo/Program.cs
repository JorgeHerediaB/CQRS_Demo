using CQRS_Demo.Context;
using CQRS_Demo.Profiles;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg => { }, typeof(ProductProfile));
builder.Services.AddAutoMapper(cfg => { }, typeof(ProductProfile), typeof(OrderQueryProfile));
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("OrdersDb"));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
