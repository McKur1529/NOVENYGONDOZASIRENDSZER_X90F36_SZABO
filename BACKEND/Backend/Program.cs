using Backend.Data; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IPlantRepository, PlantRepository>(); 

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
