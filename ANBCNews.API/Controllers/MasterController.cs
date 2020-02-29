using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANBCNews.BusinessLayer.Master;
using ANBCNews.Model;
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
        public APIResponse ImageType()
        {
            APIResponse objResponse = new APIResponse();
            try
            {
                MasterDetails obj = new MasterDetails();
                objResponse.Collection = obj.GetImageType();
                objResponse.StatusCode = "200";
                objResponse.StatusMessage = "API sucussfully processed";
            }
            catch (Exception ex)
            {
                objResponse.StatusMessage = ex.Message;
                objResponse.StatusCode = "10501";
            }
            return objResponse;
        }
        [HttpGet("NewsType")]
        public APIResponse NewsType()
        {
            APIResponse objResponse = new APIResponse();
            try
            {
                MasterDetails obj = new MasterDetails();
                objResponse.Collection = obj.GetNewsType();
                objResponse.StatusCode = "200";
                objResponse.StatusMessage = "API sucussfully processed";
            }
            catch (Exception ex)
            {
                objResponse.StatusMessage = ex.Message;
                objResponse.StatusCode = "10501";
            }
            return objResponse;
        }
    }
}
