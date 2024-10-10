using Microsoft.EntityFrameworkCore;
using POSWebApi.Data;
using POSWebApi.Repositories;
using POSWebApi.Repositories.IRepositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<POSDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Apply pending migrations and create database if it doesn't exist
using(var scope = app.Services.CreateScope()){
    var dbContext = scope.ServiceProvider.GetRequiredService<POSDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();
