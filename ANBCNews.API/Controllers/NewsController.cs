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

        [HttpGet("NewsHeadlines/{SectionID}")]
        public IEnumerable<NewsHeadline> NewsHeadlines(int SectionID)
        {
            NewsDetails obj = new NewsDetails();
            return obj.GetNewsHeadlines(0, SectionID);
        }

        [HttpGet("NewsHeadlinesByType/{NewsTypeID}")]
        public IEnumerable<NewsHeadline> NewsByType(int NewsTypeID)
        {
            NewsDetails obj = new NewsDetails();
            return obj.GetNewsHeadlines(NewsTypeID, 0);
        }
    }
} 