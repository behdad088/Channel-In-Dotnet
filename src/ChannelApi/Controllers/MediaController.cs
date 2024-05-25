using ChannelApi.Models;
using ChannelApi.Service.Notification;
using ChannelApi.Service.Report;
using ChannelApi.Service.ReportChannel;
using Microsoft.AspNetCore.Mvc;

namespace ChannelApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MediaController(
        IMediaUploader notification,
        IReport report,
        IReportChannel reportChannel) : ControllerBase
    {
        [HttpPost("UploadVideo")]
        public async Task<IActionResult> UploadVideoAsync([FromBody] VideoRequest request)
        {
            await notification.UploadVideoAsync(request).ConfigureAwait(false);
            await report.RegisterAsync(new ReportModel(request, nameof(VideoRequest))).ConfigureAwait(false);
            return Ok();
        }

        [HttpPost("UploadMp3")]
        public async Task<IActionResult> UploadMp3Sync([FromBody] Mp3Request request)
        {
            await notification.UploadMp3Sync(request).ConfigureAwait(false);
            await report.RegisterAsync(new ReportModel(request, nameof(Mp3Request))).ConfigureAwait(false);
            return Ok();
        }

        [HttpPost("channel/UploadVideo")]
        public async Task<IActionResult> ChannelUploadVideoAsync([FromBody] VideoRequest request)
        {
            await notification.UploadVideoAsync(request).ConfigureAwait(false);
            await reportChannel.ProduceAsync(new ReportModel(request, nameof(VideoRequest))).ConfigureAwait(false);
            return Ok();
        }

        [HttpPost("channel/UploadMp3")]
        public async Task<IActionResult> ChannelUploadMp3Sync([FromBody] Mp3Request request)
        {
            await notification.UploadMp3Sync(request).ConfigureAwait(false);
            await reportChannel.ProduceAsync(new ReportModel(request, nameof(Mp3Request))).ConfigureAwait(false);
            return Ok();
        }
    }
}
