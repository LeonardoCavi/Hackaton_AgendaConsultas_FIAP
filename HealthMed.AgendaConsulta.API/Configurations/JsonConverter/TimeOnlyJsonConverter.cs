using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HealthMed.AgendaConsulta.API.Configurations.JsonConverter
{
    [ExcludeFromCodeCoverage]
    public class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
    {
        private readonly string _timeFormat = "HH:mm:ss";

        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (TimeOnly.TryParseExact(reader.GetString(), _timeFormat, null, System.Globalization.DateTimeStyles.None, out var time))
            {
                return time;
            }

            throw new JsonException("Formato de hora inválido");
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_timeFormat));
        }
    }
}
