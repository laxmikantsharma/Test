using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANBCNews.BusinessLayer.News;
using ANBCNews.Model.News;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ANBCNews.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
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
        [HttpGet("NewsByType/{NewsTypeID}/{PageNo}")]
        public IEnumerable<NewsHeadline> NewsByType(int NewsTypeID, int PageNo)
        {
            NewsDetails obj = new NewsDetails();
            NewsParam objNewsParam =  new NewsParam { PageNo = PageNo,NewsTypeID = NewsTypeID };
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