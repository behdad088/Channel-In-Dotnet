using ChannelApi.Models;

namespace ChannelApi.Service.Report
{
    public interface IReport
    {
        Task RegisterAsync(ReportModel reports);
    }
}
