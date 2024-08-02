using System.Text.Json.Serialization;
using System.Text.Json;

namespace HealthMed.AgendaConsulta.API.Configurations.JsonConverter
{
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
