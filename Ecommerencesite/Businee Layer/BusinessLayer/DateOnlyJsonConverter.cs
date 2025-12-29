using Microsoft.VisualBasic;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class DateOnlyJsonConverter : JsonConverter<DateTime?>
          {
                    private const string DateFormat = "dd/MM/yyyy";

                    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
                    {
                              var value = reader.GetString();

                              if (string.IsNullOrEmpty(value))
                                        return null;

                              return DateTime.ParseExact(
                                  value,
                                  DateFormat,
                                  CultureInfo.InvariantCulture
                              );
                    }

                    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
                    {
                              if (value.HasValue)
                                        writer.WriteStringValue(value.Value.ToString(DateFormat));
                              else
                                        writer.WriteNullValue();
                    }
          }
}
