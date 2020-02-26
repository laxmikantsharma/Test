using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANBCNews.API.Auth;
using ANBCNews.Model.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using ANBCNews.BusinessLayer.User;
using ANBCNews.Model;
using ANBCNews.BusinessLayer.Config;
using ANBCNews.Utility;
using Microsoft.AspNetCore.Authorization;

namespace ANBCNews.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;

        public AccountController(IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
        {
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
        }

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromForm]UserInfo credentials)
        {
            Response objResponse = new Response();
            UserInfo obj = null;
            try
            {
                UserDetails acc = new UserDetails();
                obj = acc.UserLogin(credentials.Username, credentials.Password);
                if (obj.UserID > 0)
                {
                    obj.Token = await Tokens.GenerateJwt(_jwtFactory.GenerateClaimsIdentity(credentials.Username, credentials.UserID.ToString()), _jwtFactory, credentials.Username, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
                    //obj.ImagePath = string.IsNullOrEmpty(obj.ImagePath) ? "" : obj.IsAWS ? new AmazonS3().DownloadUrSigned(obj.ImagePath) : iConfiguration.GetSection("AppSetting").GetSection("Mrigs").Value + "/" + obj.ImagePath;
                    objResponse.ID = obj.UserID;
                    objResponse.Result = obj.UserID > 0;
                    objResponse.obj = obj;
                }
                else
                {
                    objResponse.Message = "Provided username and password is incorrect";
                }
            }
            catch (Exception ex)
            {
                objResponse.Message = ex.Message;
                CLogger.WriteLog(ProjectSource.WebApi, ELogLevel.ERROR, "ERROR ocurred in  Account Controller  while calling LoginUser Action, Ex.: " + ex.Message);
            }
            return Ok(objResponse);
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody]string Username)
        {
            Response objResponse = new Response();
            try
            {
                if (!string.IsNullOrEmpty(Username))
                {
                    UserDetails acc = new UserDetails();
                    UserInfo obj = acc.GetUserInfo(new UserInfo { Username=Username });
                    string recoveryToken = acc.GenerateToken(Username);

                    if (obj != null && obj.UserID > 0 && !string.IsNullOrEmpty(recoveryToken))
                    {
                        EmailService objEmailService = new EmailService();
                        string url = ConfigurationSetting.WebAppUrl;
                        objEmailService.ForgetPassword(TemplateCode.FORGETPASSWORD.ToString(), obj.Email, obj.FirstName, url, recoveryToken);
                        objResponse.Message = "Thank You! Account recovery email sent to " + obj.Email;
                        objResponse.Result = true;
                    }
                    else
                    {
                        objResponse.Message = "Email is not related to any existing account!";
                    }
                }
                else
                {
                    objResponse.Message = AppMessage.UnknownError;
                }
            }
            catch (Exception ex)
            {
                objResponse.Message = ex.Message;
                CLogger.WriteLog(ProjectSource.WebApi, ELogLevel.ERROR, "ERROR ocurred in  Account Controller  while calling ForgotPassword Action, Ex.: " + ex.Message);
            }
            return Ok(new { Response = objResponse });
        }

        [HttpGet("CheckTokenResetPassword/{recoveryToken}")]
        public async Task<IActionResult> CheckTokenResetPassword(string recoveryToken)
        {
            Response objResponse = new Response();
            try
            { 
                if (!string.IsNullOrEmpty(recoveryToken))
                {
                    UserDetails objUserDetails = new UserDetails();
                    TokenBucket objTokenBucket = new TokenBucket();

                    objTokenBucket = objUserDetails.GetToken(recoveryToken);
                    if (objTokenBucket != null && objTokenBucket.ID > 0)
                    {
                        if (objTokenBucket.ValidFrom <= DateTime.Now && objTokenBucket.ValidTo >= DateTime.Now && (!objTokenBucket.IsUsed) && (objTokenBucket.IsActive))
                        {

                            objResponse.Result = true;
                            objResponse.Message = "";
                        }
                        else
                        {
                            objResponse.Message = "Token request is expired!.";
                        }
                    }
                    else
                    {
                        objResponse.Message = "invalid Token request!.";
                    }

                }
            }
            catch (Exception ex)
            {
                CLogger.WriteLog(ProjectSource.WebApi, ELogLevel.ERROR, "ERROR ocurred in  Account Controller  while calling CheckTokenResetPassword Action, Ex.: " + ex.Message);
            }

            return Ok(new { Response = objResponse });
        }

        [HttpPost("ResetPassword/{recoveryToken}")]
        public async Task<IActionResult> ResetPassword([FromBody]ResetPassword objModel, string recoveryToken)
        {
            Response objResponse = null;
            UserDetails objUserDetails = new UserDetails();
            TokenBucket objTokenBucket = new TokenBucket(); 
            UserInfo objUserEntity = new UserInfo();
            try
            {
                if (!string.IsNullOrEmpty(objModel.Password))
                {
                    objTokenBucket = objUserDetails.GetToken(recoveryToken);
                    UserInfo obj = objUserDetails.GetUserInfo(new UserInfo { Username= objTokenBucket.Username});
                    if (objTokenBucket.ValidFrom <= DateTime.Now && objTokenBucket.ValidTo >= DateTime.Now && (!objTokenBucket.IsUsed) && (objTokenBucket.IsActive))
                    {
                        objUserEntity.Email = obj.Email;
                        objUserEntity.Username = obj.Username;
                        objUserEntity.Password = Constants.GetMD5Hash(objModel.Password);// objModel.PasswordMD5;
                        objResponse = objUserDetails.UpdateUserPassword(objUserEntity);
                        if (objResponse.Result)
                        {
                            objUserDetails.ExpireToken(recoveryToken); 
                            objResponse.Message = "Your password reset successfully.";
                        }
                        else 
                        {
                            objResponse.Message = "Your password should not be same as last 3 password.";
                        }
                    }
                    else
                    {
                        objResponse.Message = "Token request is expired!.";
                    }
                }
                else
                {
                    objResponse.Message = "some error occurred.";
                }
            }
            catch (Exception ex)
            {
                objResponse.Message = ex.Message;
                CLogger.WriteLog(ProjectSource.WebApi, ELogLevel.ERROR, "ERROR ocurred in  Account Controller  while calling ResetPassword Action, Ex.: " + ex.Message);

            }
            return Ok(new { Response = objResponse});
        }

        [HttpPost("ChangePassword")]
        [Authorize(Policy = "Member")]
        public async Task<IActionResult> ChangePassword([FromBody]ResetPassword objModel)
        {
            UserDetails objUserDetails = new UserDetails();
            UserInfo objUserEntity = new UserInfo();
             Response objResult = null;
            try
            {
                if (ModelState.IsValid)
                {
                    string Username = User.FindFirst("Username")?.Value;

                    UserInfo obj = objUserDetails.GetUserInfo(new UserInfo { Username = Username });

                    if (obj.Password == Constants.GetMD5Hash(objModel.OldPassword))
                    {
                        objUserEntity.Username = Username;
                        objUserEntity.Password = Constants.GetMD5Hash(objModel.Password);
                        objResult = objUserDetails.UpdateUserPassword(objUserEntity);
                        if (objResult != null)
                        {
                            objResult.Message = (objResult.Action == 2) ? "Your password successfully changed."
                                 : (objResult.Action == -1) ? "Your password should not be same as last 3 password" : "some error occurred.";
                            objResult.Result = (objResult.Action == 2) ? true : false;
                        }
                        else
                        {
                            objResult.Message = "some error occurred.";
                        }
                    }
                    else
                        objResult.Message = "Old Password is Incorrect.";
                }
                else
                {
                    objResult.Message = "Form not valid!";
                }

            }
            catch (Exception ex)
            {
                objResult.Message = ex.Message;
                CLogger.WriteLog(ProjectSource.WebApi, ELogLevel.ERROR, "ERROR ocurred in  Account Controller  while calling ChangePassword Action, Ex.: " + ex.Message);

            }
            return Ok(new { Response = objResult});

        }

    }
}