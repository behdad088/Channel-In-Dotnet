using ChannelApi.Models;

namespace ChannelApi.Service.Notification
{
    public class Notification : INotification
    {
        public async Task ScheduleSendSync(ScheduleNotificationRequest request)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            await Task.CompletedTask;
        }

        public async Task SendAsync(SendNotificationRequest request)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            await Task.CompletedTask;
        }
    }
}
