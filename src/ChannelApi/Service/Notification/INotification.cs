using ChannelApi.Models;

namespace ChannelApi.Service.Notification
{
    public interface INotification
    {
        Task SendAsync(SendNotificationRequest request);
        Task ScheduleSendSync(ScheduleNotificationRequest request);
    }
}
