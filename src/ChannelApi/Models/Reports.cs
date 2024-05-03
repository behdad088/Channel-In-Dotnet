namespace ChannelApi.Models
{
    public record ReportModel
    {
        public object Event { get; init; }
        public string EventName { get; init; }
        public DateTime EventDate { get; init; } = DateTime.Now;

        public ReportModel(object @event, string eventName)
        {
            Event = @event;
            EventName = eventName;
        }
    }
}
