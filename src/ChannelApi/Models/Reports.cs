namespace ChannelApi.Models
{
    public record ReportModel(object Event, string EventName)
    {
        public DateTime EventDate { get; init; } = DateTime.Now;
    }
}
