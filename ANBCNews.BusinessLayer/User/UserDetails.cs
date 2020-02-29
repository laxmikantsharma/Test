using ANBCNews.DataAccessLayer.News;
using ANBCNews.DataAccessLayer.User;
using ANBCNews.Model;
using ANBCNews.Model.News;
using ANBCNews.Model.User;
using ANBCNews.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANBCNews.BusinessLayer.User
{
    public class UserDetails
    {
        public UserInfo GetUserInfo(UserInfo objParm)
        {
            UserDataAccess objDataAccess = new UserDataAccess();
            return objDataAccess.GetUserInfo(objParm);
        }
        public UserInfo UserLogin(string Username, string Password)
        {
            UserDataAccess objDataAccess = new UserDataAccess();
            UserInfo objParm = new UserInfo();
            objParm.Username = Username;
            objParm.Password = Password;
            UserInfo obj = objDataAccess.GetUserInfo(objParm);
            if (obj != null && obj.UserID > 0 && obj.Password == Constants.GetMD5Hash(objParm.Password))
            {
                obj.Password = "";
                return obj;
            }
            else
            {
                return new UserInfo(); ;
            }
        }
        public string GenerateToken(string Username, string Token = "")
        {

            UserDataAccess objDataAccess = new UserDataAccess();
            TokenBucket objTokenBucket = new TokenBucket();
            objTokenBucket.Username = Username;
            objTokenBucket.ValidFrom = DateTime.Now;
            objTokenBucket.ValidTo = DateTime.Now.AddMinutes(15);
            objTokenBucket.Token = string.IsNullOrEmpty(Token) ? Guid.NewGuid().ToString() : Token;
            if (objDataAccess.GenerateToken(objTokenBucket))
            {
                return objTokenBucket.Token;
            }
            return "";
        }
        public TokenBucket GetToken(string Token)
        {
            UserDataAccess objDataAccess = new UserDataAccess();
            return objDataAccess.GetToken(Token);
        }
        public DBResponse UpdateUserPassword(UserInfo objUserInfo)
        {
            UserDataAccess objDataAccess = new UserDataAccess();
            return objDataAccess.UpdateUserPassword(objUserInfo);
        }
        public bool ExpireToken(string Token)
        {
            UserDataAccess objDataAccess = new UserDataAccess();
            return objDataAccess.ExpireToken(Token);
        }
    }

}
