using ChannelApi.Models;

namespace ChannelApi.Service.ReportChannel
{
    public interface IReportChannel
    {
        Task ProduceAsync(ReportModel message);
        ValueTask<ReportModel> ConsumeAsync(CancellationToken cancellationToken);
    }
}
