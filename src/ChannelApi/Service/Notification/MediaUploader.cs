using ChannelApi.Models;

namespace ChannelApi.Service.Notification
{
    public class MediaUploader : IMediaUploader
    {
        public async Task UploadMp3Sync(Mp3Request request)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
        }

        public async Task UploadVideoAsync(VideoRequest request)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
        }
    }
}
