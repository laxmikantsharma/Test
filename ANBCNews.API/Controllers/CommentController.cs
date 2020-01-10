using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANBCNews.BusinessLayer.Master;
using ANBCNews.Model;
using ANBCNews.Model.Comment;
using ANBCNews.Model.Master;
using ANBCNews.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ANBCNews.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {

        [HttpPost()]
        public ActionResult SaveContact([FromBody]CommentEntity objComment)
        {
                DBResponse obj = new DBResponse();
            if (ModelState.IsValid)
            {
                    CommentDetails objCommentDetails = new CommentDetails();
                    obj = objCommentDetails.SaveComment(objComment);
                    obj.ResponseResult = obj.ID > 0;
                    obj.Message = obj.ResponseResult ? "Thanks for reply." : AppMessage.SystemError;
               
            }
            else
            {
                obj.ResponseResult = false;
                obj.Message = "Please fill in all required fields"; 
            }
            return Ok(new{ ResponseResult = obj.ResponseResult, Message = obj.Message });
        }
    }
}
