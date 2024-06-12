using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DemoRestAPI.Helpers
{
    public class DateConverter : JsonConverter<DateTime>
    {
        private readonly static string DATE_FORMAT_STRING = "yyyy-MM-dd HH:mm:ss";
        private readonly static CultureInfo cultureInfo = new CultureInfo("en-GB");

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString(), DATE_FORMAT_STRING, cultureInfo);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToUniversalTime().ToString(DATE_FORMAT_STRING, cultureInfo));
        }
    }
}
