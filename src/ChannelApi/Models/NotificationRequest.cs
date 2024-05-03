using System.Text.Json.Serialization;

namespace ChannelApi.Models
{
    public record SendNotificationRequest(
        [property: JsonPropertyName("email")]
        string? Email,
        [property: JsonPropertyName("message")]
        string? Message);

    public record ScheduleNotificationRequest(
        [property: JsonPropertyName("email")]
        string? Email,
        [property: JsonPropertyName("message")]
        string? Message,
        [property: JsonPropertyName("due_date")]
        string? DueDate);
}
