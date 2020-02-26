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

        public NewsController( IConfiguration configuration)
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
        public NewsHeader GetNewsDetail(int NewsID)
        {
            NewsDetails obj = new NewsDetails();
            return obj.GetNewsDetail(NewsID);
        }

        [HttpGet("NewsHeadlines/{SectionID}")]
        public IEnumerable<NewsHeadline> NewsHeadlines(int SectionID)
        {
            NewsDetails obj = new NewsDetails();
            NewsParam objNewsParam =  new NewsParam {SectionID= SectionID };
            return obj.GetNewsHeadlines(objNewsParam);
        }

        [HttpGet("LatestNews/{PageNo}")]
        public IEnumerable<NewsHeadline> LatestNews(int PageNo)
        {
            NewsDetails obj = new NewsDetails();
            NewsParam objNewsParam =  new NewsParam { PageNo = PageNo };
            return obj.GetNewsHeadlines(objNewsParam);
        }
        [HttpGet("NewsByType/{NewsTypeID}/{OnlyVideo}/{PageNo}")]
        public IEnumerable<NewsHeadline> NewsByType(int NewsTypeID,bool OnlyVideo, int PageNo)
        {
            NewsDetails obj = new NewsDetails();
            NewsParam objNewsParam =  new NewsParam { PageNo = PageNo, OnlyVideo = OnlyVideo, NewsTypeID = NewsTypeID };
            return obj.GetNewsHeadlines(objNewsParam);
        }
         
        [HttpGet("Search/{PageNo}/{Keyword}")]
        public IEnumerable<NewsHeadline> SearchNews(int PageNo,string Keyword)
        {
            NewsDetails obj = new NewsDetails();
            return obj.SearchNews(PageNo,Keyword);
        }

    }

} 