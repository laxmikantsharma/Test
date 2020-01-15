using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ANBCNews.BusinessLayer.Master;
using ANBCNews.Model;
using ANBCNews.Model.Contact;
using ANBCNews.Utility;


namespace ANBCNews.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : Controller
    {
        [HttpPost()]
        public ActionResult SaveContact([FromBody]ContactEntity objContact)
        {
            DBResponse obj = new DBResponse();
            if (ModelState.IsValid)
            {
                ContactDetails objContactDetails = new ContactDetails();
                obj = objContactDetails.SaveContact(objContact);
                obj.ResponseResult = obj.ID > 0;
                obj.Message = obj.ResponseResult ? "Thanks for your query. We will contact you soon." : AppMessage.SystemError;

            }
            else
            {
                obj.ResponseResult = false;
                obj.Message = "Please fill in all required fields";
            }
            return Ok(new { ResponseResult = obj.ResponseResult, Message = obj.Message });
        }
    }
}
