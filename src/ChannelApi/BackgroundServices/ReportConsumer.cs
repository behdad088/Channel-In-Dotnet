
using ChannelApi.Service.Report;
using ChannelApi.Service.ReportChannel;

namespace ChannelApi.BackgroundServices
{
    public class ReportConsumer(IReportChannel reportChannel, IReport report) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var message = await reportChannel.ConsumeAsync(stoppingToken).ConfigureAwait(false);
                await report.RegisterAsync(message).ConfigureAwait(false);
            }
        }
    }
}
