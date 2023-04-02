using Microsoft.EntityFrameworkCore;
using MovieMicroservice.Configurations;
using MovieMicroservice.Services;

var builder = WebApplication.CreateBuilder(args);

var sqlConnectionString = Environment.GetEnvironmentVariable("ConnectionString");

if (sqlConnectionString == null)
{
    sqlConnectionString = builder.Configuration.GetConnectionString("MovieDbConnectionString");
}

builder.Services.AddDbContext<DbConfig>(optionsAction: optionsBuilder =>
    optionsBuilder.UseNpgsql(sqlConnectionString,
    optionsAction =>
    {
        optionsAction.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
    }
    ));

builder.Services.AddScoped<IMovieService, MovieService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
