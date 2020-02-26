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
            string str = "";
            bool isSeek = false;
            var req = new ThumbnailRequest();
            //req.RequestedPath = ImageName;
            req.ThumbnailSize = ParseSize(Size);
            req.SourceImagePath = GetPhysicalPath(NewsID+"/"+ImageName);
            if (IsSourceImageExists(req))
            {
                using (Image img = Image.FromFile(req.SourceImagePath))
                {
                    try
                    {

                    
                    Image file = null;
                        str = "Width: " + req.ThumbnailSize.Value.Width + " Height: " + req.ThumbnailSize.Value.Height;
                       
                        if (req.ThumbnailSize.Value.Height >= req.ThumbnailSize.Value.Width)
                      file = ImageResize.ScaleByHeight(img, req.ThumbnailSize.Value.Height);
                        str = "2 Width: " + req.ThumbnailSize.Value.Width + " Height: " + req.ThumbnailSize.Value.Height;

                        if (req.ThumbnailSize.Value.Width > req.ThumbnailSize.Value.Height)
                        file = ImageResize.ScaleByWidth(img, req.ThumbnailSize.Value.Width);
                        str = "3 Width: " + req.ThumbnailSize.Value.Width + " Height: " + req.ThumbnailSize.Value.Height;
                   
                        file = ImageResize.ScaleAndCrop(file, req.ThumbnailSize.Value.Width, req.ThumbnailSize.Value.Height, TargetSpot.Center);
                        str = "4 Width: " + req.ThumbnailSize.Value.Width + " Height: " + req.ThumbnailSize.Value.Height;

                        Stream outputStream = new MemoryStream();

                    file.Save(outputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    outputStream.Seek(0, SeekOrigin.Begin);
                        str = "5 Width: " + req.ThumbnailSize.Value.Width + " Height: " + req.ThumbnailSize.Value.Height;

                        return this.File(outputStream, "image/png");
                    }
                    catch (Exception ex)
                    {
                        return NotFound(str+" "+ex.Message + " inner " + Convert.ToString( ex.InnerException));

                    }
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