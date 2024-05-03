using ChannelApi.Models;
using Newtonsoft.Json;
using System.Collections.Concurrent;

namespace ChannelApi.Service.Report
{
    public class Report : IReport
    {
        private readonly ConcurrentBag<List<ReportModel>> reports;
        private readonly List<ReportModel> _temporaryItems = [];
        private static string AbsolutePath => Directory.GetCurrentDirectory() + "/report.json";

        public Report()
        {
            var content = File.ReadAllText(AbsolutePath);
            reports = JsonConvert.DeserializeObject<ConcurrentBag<List<ReportModel>>>(content) ?? [];
        }

        public async Task RegisterAsync(ReportModel reports)
        {
            _temporaryItems.Add(reports);

            if (_temporaryItems.Count > 2)
            {
                await WriteAsync();
            }
        }

        private async Task WriteAsync()
        {
            reports.Add(_temporaryItems.ToList());
            var content = JsonConvert.SerializeObject(reports);
            await File.WriteAllTextAsync(AbsolutePath, content);
            _temporaryItems.Clear();
        }
    }
}
