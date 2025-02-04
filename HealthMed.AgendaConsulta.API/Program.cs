using HealthMed.AgendaConsulta.API.Configurations;
using HealthMed.AgendaConsulta.API.Configurations.JsonConverter;
using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContextConfiguration(builder.Configuration);
builder.Services.AddParameters(builder.Configuration);
builder.Services.AddAutenticationConfiguration(builder.Configuration);
builder.Services.AddDependencyInjection();
builder.Services.AddAzureComunicationServiceConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseSwaggerConfiguration();

app.UseAuthorization();

app.MapControllers();

app.Run();

[ExcludeFromCodeCoverage]
public static partial class Program { }
