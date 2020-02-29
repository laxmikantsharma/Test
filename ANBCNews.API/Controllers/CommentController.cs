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
            APIResponse objResponse = new APIResponse();
            try
            {

                if (ModelState.IsValid)
                {
                    DBResponse obj = new DBResponse();
                    CommentDetails objCommentDetails = new CommentDetails();
                    obj = objCommentDetails.SaveComment(objComment);
                    obj.Result = obj.ID > 0;
                    objResponse.StatusMessage = obj.Result ? "Thanks for reply." : AppMessage.SystemError;
                    objResponse.StatusCode = obj.Result ? "200" : "501";
                }
                else
                {
                    objResponse.StatusCode = "502";
                    objResponse.StatusMessage = "Please fill in all required fields";
                }
            }
            catch (Exception ex)
            {
                objResponse.StatusMessage = ex.Message;
                objResponse.StatusCode = "10501";
            }
            return Ok(objResponse);
        }
    }
}
