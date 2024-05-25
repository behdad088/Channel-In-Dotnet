using ChannelApi.Models;

namespace ChannelApi.Service.Notification
{
    public interface IMediaUploader
    {
        Task UploadVideoAsync(VideoRequest request);
        Task UploadMp3Sync(Mp3Request request);
    }
}
