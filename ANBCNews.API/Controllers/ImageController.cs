using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ANBCNews.Model.Gallery;
using LazZiya.ImageResize;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace ANBCNews.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly ImageThumbnailOptions _options;
        public ImageController()
        {
            _options = new ImageThumbnailOptions();
        }

        //[HttpGet("News/{NewsID}/{Size}/{ImageName}")]
        [HttpGet("{NewsID}/{Size}/{ImageName}")] 
        public async Task<IActionResult> Get(string NewsID, string Size, string ImageName)
        {
            var req = new ThumbnailRequest();
            //req.RequestedPath = ImageName;
            req.ThumbnailSize = ParseSize(Size);
            req.SourceImagePath = GetPhysicalPath(NewsID+"/"+ImageName);
            if (IsSourceImageExists(req))
            {
                using (Image img = Image.FromFile(req.SourceImagePath))
                {
                    Image file = null;

                    if (req.ThumbnailSize.Value.Height >= req.ThumbnailSize.Value.Width)
                      file = ImageResize.ScaleByHeight(img, req.ThumbnailSize.Value.Height);

                    if (req.ThumbnailSize.Value.Width > req.ThumbnailSize.Value.Height)
                        file = ImageResize.ScaleByWidth(img, req.ThumbnailSize.Value.Width);

                    file = ImageResize.ScaleAndCrop(file, req.ThumbnailSize.Value.Width, req.ThumbnailSize.Value.Height, TargetSpot.Center);

                    Stream outputStream = new MemoryStream();

                    file.Save(outputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    outputStream.Seek(0, SeekOrigin.Begin);

                    return this.File(outputStream, "image/png");
                }
            }
            return NotFound();
        }

        [HttpGet("{NewsID}/{ImageName}")]
        public async Task<IActionResult> Get(string NewsID, string ImageName)
        {
            var req = new ThumbnailRequest();
            req.SourceImagePath = GetPhysicalPath(NewsID + "/" + ImageName);
            if (IsSourceImageExists(req))
            {
                using (Image img = Image.FromFile(req.SourceImagePath))
                {
                    Stream outputStream = new MemoryStream();
                    img.Save(outputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    outputStream.Seek(0, SeekOrigin.Begin);
                    return this.File(outputStream, "image/png");
                }
            }
            return NotFound();
        }
        private bool IsSourceImageExists(ThumbnailRequest request)
        {
            if (System.IO.File.Exists(request.SourceImagePath))
            {
                return true;
            }

            return false;
        }
        private string GetPhysicalPath(string path)
        {
            var provider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), _options.ImagesDirectory));
            var fileInfo = provider.GetFileInfo(path);

            return fileInfo.PhysicalPath;
        }
        private Size? ParseSize(string size)
        {
            var _size = _options.DefaultSize.Value;

            try
            {
                if (!string.IsNullOrEmpty(size))
                {
                    size = size.ToLower();
                    if (size.Contains("x"))
                    {
                        var parts = size.Split('x');
                        _size.Width = int.Parse(parts[0]);
                        _size.Height = int.Parse(parts[1]);
                    }
                    else if (size == "full")
                    {
                        return new Nullable<Size>();
                    }
                    else
                    {
                        _size.Width = int.Parse(size);
                        _size.Height = int.Parse(size);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }


            return _size;
        }


    }
}