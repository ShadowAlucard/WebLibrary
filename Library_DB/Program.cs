using Library_DB;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog(
    (_, loggerConfiguration) => loggerConfiguration
                    .MinimumLevel.Debug()
                    .WriteTo.Console());

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<LibraryContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"));
        options.UseLazyLoadingProxies();
    });
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
