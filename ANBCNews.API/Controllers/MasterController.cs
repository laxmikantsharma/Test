using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANBCNews.BusinessLayer.Master;
using ANBCNews.Model.Master;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ANBCNews.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MasterController : ControllerBase
    {

        [HttpGet("ImageType")]
        public IEnumerable<MasterImageType> ImageType()
        {
            MasterDetails obj = new MasterDetails();
            return obj.GetImageType();
        }
        [HttpGet("NewsType")]
        public IEnumerable<MasterNewsType> NewsType()
        {
            MasterDetails obj = new MasterDetails();
            return obj.GetNewsType();
        }
    }
}
