using ChannelApi.Models;
using ChannelApi.Service.Notification;
using ChannelApi.Service.Report;
using ChannelApi.Service.ReportChannel;
using Microsoft.AspNetCore.Mvc;

namespace ChannelApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly ILogger<NotificationController> _logger;
        private readonly INotification _notification;
        private readonly IReport _report;
        private readonly IReportChannel _reportChannel;

        public NotificationController(
            ILogger<NotificationController> logger,
            INotification notification,
            IReport report,
            IReportChannel reportChannel)
        {
            _logger = logger;
            _notification = notification;
            _report = report;
            _reportChannel = reportChannel;
        }

        [HttpPost("SendNotification")]
        public async Task<IActionResult> SendNotification([FromBody] SendNotificationRequest request)
        {
            await _notification.SendAsync(request);
            await _report.RegisterAsync(new ReportModel(request, nameof(SendNotificationRequest)));
            return Ok();
        }

        [HttpPost("ScheduleNotification")]
        public async Task<IActionResult> ScheduleNotification([FromBody] ScheduleNotificationRequest request)
        {
            await _notification.ScheduleSendSync(request);
            await _report.RegisterAsync(new ReportModel(request, nameof(ScheduleNotificationRequest)));
            return Ok();
        }

        [HttpPost("channel/SendNotification")]
        public async Task<IActionResult> ChannelSendNotification([FromBody] SendNotificationRequest request)
        {
            await _notification.SendAsync(request);
            await _reportChannel.ProduceAsync(new ReportModel(request, nameof(SendNotificationRequest)));
            return Ok();
        }

        [HttpPost("channel/ScheduleNotification")]
        public async Task<IActionResult> ChannelScheduleNotification([FromBody] ScheduleNotificationRequest request)
        {
            await _notification.ScheduleSendSync(request);
            await _reportChannel.ProduceAsync(new ReportModel(request, nameof(ScheduleNotificationRequest)));
            return Ok();
        }
    }
}
