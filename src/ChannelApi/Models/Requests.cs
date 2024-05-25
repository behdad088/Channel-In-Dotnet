using System.Text.Json.Serialization;

namespace ChannelApi.Models
{
    public record VideoRequest(
        [property: JsonPropertyName("name")]
        string? Name,
        [property: JsonPropertyName("artist")]
        string? Artist,
        [property: JsonPropertyName("size")]
        int? Size,
        [property: JsonPropertyName("length")]
        decimal? Length);


    public record Mp3Request(
        [property: JsonPropertyName("name")]
        string? Name,
        [property: JsonPropertyName("artist")]
        string? Artist,
        [property: JsonPropertyName("size")]
        int? Size,
        [property: JsonPropertyName("length")]
        decimal? Length);
}
