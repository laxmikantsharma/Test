using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANBCNews.BusinessLayer.News;
using ANBCNews.Model.News;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using ANBCNews.Model;

namespace ANBCNews.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public NewsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //[HttpGet]
        //public string Get()
        //{
        //    try
        //    {
        //        ConfigurationSetting.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        //        ConfigurationSetting.ImageWebUrl = _configuration.GetSection("AppSetting").GetSection("ImageWebUrl").Value;
        //        string str = _configuration.GetSection("ASPNETCORE_ENVIRONMENT").Value;

        //        ConfigurationSetting.ConnectionString = ConfigurationSetting.ConnectionString == null ? "ConnectionString Null" : ConfigurationSetting.ConnectionString;

        //        ConfigurationSetting.ImageWebUrl = _configuration.GetSection("AppSetting") == null ? "AppSetting Null" : _configuration.GetSection("AppSetting").GetSection("ImageWebUrl") == null ? "ImageWebUrl Null" : _configuration.GetSection("AppSetting").GetSection("ImageWebUrl").Value;

        //        NewsHeader obj = null;
        //        obj = new NewsDetails().GetNewsDetail(1);

        //       return ConfigurationSetting.ConnectionString + " 2. " + ConfigurationSetting.ImageWebUrl + "3. " + obj.Headline; // here  
        //    }
        //    catch (Exception ex)
        //    {

        //        return ConfigurationSetting.ConnectionString + " 2. " + ConfigurationSetting.ImageWebUrl + "3. " + ex.Message; // here  
        //    }
        //}

        [HttpGet("Detail/{NewsID}")]
        public async Task<APIResponse> GetNewsDetail(int NewsID)
        {
            APIResponse objResponse = new APIResponse();
            try
            {
                NewsDetails obj = new NewsDetails();
                objResponse.Object = obj.GetNewsDetail(NewsID);
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

        [HttpGet("NewsHeadlines/{SectionID}")]
        public async Task<APIResponse> NewsHeadlines(int SectionID)
        {
            APIResponse objResponse = new APIResponse();
            try
            {
                NewsDetails obj = new NewsDetails();
                NewsParam objNewsParam = new NewsParam { SectionID = SectionID };
                objResponse.Collection = obj.GetNewsHeadlines(objNewsParam);
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

        [HttpGet("LatestNews/{PageNo}")]
        public async Task<APIResponse> LatestNews(int PageNo)
        {
            APIResponse objResponse = new APIResponse();
            try
            {
                NewsDetails obj = new NewsDetails();
                NewsParam objNewsParam = new NewsParam { PageNo = PageNo };
                objResponse.Collection = obj.GetNewsHeadlines(objNewsParam);
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
        [HttpGet("NewsByType/{NewsTypeID}/{OnlyVideo}/{PageNo}")]
        public async Task<APIResponse> NewsByType(int NewsTypeID, bool OnlyVideo, int PageNo)
        {
            APIResponse objResponse = new APIResponse();
            try
            {
                NewsDetails obj = new NewsDetails();
                NewsParam objNewsParam = new NewsParam { PageNo = PageNo, OnlyVideo = OnlyVideo, NewsTypeID = NewsTypeID };
                objResponse.Collection = obj.GetNewsHeadlines(objNewsParam);
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

        [HttpGet("Search/{PageNo}/{Keyword}")]
        public async Task<APIResponse> SearchNews(int PageNo, string Keyword)
        {
            APIResponse objResponse = new APIResponse();
            try
            {
                NewsDetails obj = new NewsDetails();
                objResponse.Collection = obj.SearchNews(PageNo, Keyword);
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