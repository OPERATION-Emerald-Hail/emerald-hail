using Microsoft.OpenApi.Models; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Emerald.Hail.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlite("Data Source=../store.db",
    m => m.MigrationsAssembly("Emerald.Hail.Api"));
});

builder.Services.AddCors(options => 
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:5173")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Emerald Hail API", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => 
{ 
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Emerald Hail API V1");
});
app.UseCors();

app.MapControllers();

app.Run();
