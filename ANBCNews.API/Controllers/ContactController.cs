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
        public async Task<APIResponse> SaveContact([FromBody]ContactEntity objContact)
        {
            APIResponse objResponse = new APIResponse();
            try
            {
                DBResponse obj = new DBResponse();
                if (ModelState.IsValid)
                {
                    ContactDetails objContactDetails = new ContactDetails();
                    obj = objContactDetails.SaveContact(objContact);
                    obj.Result = obj.ID > 0;
                    objResponse.StatusMessage = obj.Result ? "Thanks for your query. We will contact you soon." : AppMessage.SystemError;
                    objResponse.StatusCode = obj.Result ? APIStatusCode.Success : APIStatusCode.InternalError;
                }
                else
                {
                    objResponse.StatusCode = APIStatusCode.ValidationFailed;
                    objResponse.StatusMessage = "Please fill in all required fields";
                }
            }
            catch (Exception ex)
            {
                objResponse.StatusMessage = ex.Message;
                objResponse.StatusCode = APIStatusCode.SystemError;
            }
            return objResponse;
        }
    }
}
