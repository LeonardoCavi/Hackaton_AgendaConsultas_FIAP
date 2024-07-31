using HealthMed.AgendaConsulta.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContextConfiguration(builder.Configuration);
builder.Services.AddParameters(builder.Configuration);
builder.Services.AddDependencyInjection();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseSwaggerConfiguration();

app.UseAuthorization();

app.MapControllers();

app.Run();
