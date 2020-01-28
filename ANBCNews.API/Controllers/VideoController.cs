using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace ANBCNews.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        [HttpGet("{NewsID}/{VideoName}")]
        public async Task<FileStreamResult> Get(string NewsID, string VideoName)
        {
            try
            {
                IVideoStreamService _streamingService = new VideoStreamService();
                var stream = await _streamingService.GetVideoByName(NewsID, VideoName);
                return new FileStreamResult(stream, "video/mp4");
            }
            catch (Exception ex)
            {
            }
            return null;
        }
    }

    public class VideoStreamService : IVideoStreamService
    {
        private HttpClient _client;

        public VideoStreamService()
        {
            _client = new HttpClient();
        }

        public async Task<Stream> GetVideoByName(string NewsID, string VideoName)
        {
            var provider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "videos" + "/" + NewsID));
            var fileInfo = provider.GetFileInfo(VideoName);
            Stream stream = new FileStream(fileInfo.PhysicalPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            return stream;
        }

        ~VideoStreamService()
        {
            if (_client != null)
                _client.Dispose();
        }
    }
    public interface IVideoStreamService
    {
        Task<Stream> GetVideoByName(string NewsID, string VideoName);
    }
}