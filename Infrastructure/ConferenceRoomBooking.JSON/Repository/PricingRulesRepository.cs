using ConferenceRoomBooking.Application.Interfaces.Repositories;
using ConferenceRoomBooking.Domain.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConferenceRoomBooking.JSON.Repository
{
    public class PricingRulesRepository : ICalculateRentRepository
    {
        public async Task<ICollection<PricingRuleEntity>> GetRulesAsync(CancellationToken cancellationToken)
        {
            var path = Path.Combine(
                AppContext.BaseDirectory,
                "..", "..", "..", "..", "..",
                "Infrastructure",
                "ConferenceRoomBooking.JSON",
                "Configuration",
                "pricingRules.json"
);

            var json = await File.ReadAllTextAsync(path, cancellationToken);

            var options = new JsonSerializerOptions
            {
                Converters = { new TimeSpanConverter() }
            };

            var rules = JsonSerializer.Deserialize<List<PricingRuleEntity>>(json, options);

            return rules ?? [];
        }
    }

    public class TimeSpanConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return TimeSpan.Parse(value!);
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(@"hh\:mm"));
        }
    }
}
