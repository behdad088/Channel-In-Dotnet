using ChannelApi.Models;
using System.Threading.Channels;

namespace ChannelApi.Service.ReportChannel
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/core/extensions/channels
    /// </summary>
    public class ReportChannel : IReportChannel
    {
        private readonly Channel<ReportModel> _channel;

        public ReportChannel()
        {
            _channel = Channel.CreateBounded<ReportModel>(new BoundedChannelOptions(100)
            {
                FullMode = BoundedChannelFullMode.Wait,
                SingleReader = true
            });
        }

        public async ValueTask<ReportModel> ConsumeAsync(CancellationToken cancellationToken)
        {
            return await _channel.Reader.ReadAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task ProduceAsync(ReportModel message)
        {
            await _channel.Writer.WriteAsync(message).ConfigureAwait(false);
        }
    }
}
