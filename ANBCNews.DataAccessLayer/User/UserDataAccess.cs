using ANBCNews.DataAccessLayer.Config;
using ANBCNews.Model;
using ANBCNews.Model.News;
using ANBCNews.Model.User;
using ANBCNews.Utility;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ANBCNews.DataAccessLayer.User
{
    public class UserDataAccess
    {
        MySqlDataAccess SqlData = null;
        public UserDataAccess()
        {
            SqlData = new MySqlDataAccess();
        }

        public UserInfo GetUserInfo(UserInfo objParm)
        {
            try
            {
                DynamicParameters objParameter = new DynamicParameters();
                objParameter.Add("p_UserID", objParm.UserID);
                objParameter.Add("p_Username", objParm.Username);
                return SqlData.dataContext.QueryFirst<UserInfo>("GetUserInfo", objParameter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CLoggerDataAccess.WriteLog(ProjectSource.DataAccessLayer, ELogLevel.ERROR, "ERROR ocurred in User Data Access while calling GetUserInfo Action, Ex.: " + ex.Message);
            }
            return null;
        }
        public bool GenerateToken(TokenBucket obj)
        {
            DynamicParameters objParameters = new DynamicParameters();
            try
            {
                objParameters.Add("@P_Token", obj.Token);
                objParameters.Add("@P_Username", obj.Username);
                objParameters.Add("@P_ValidFrom", obj.ValidFrom);
                objParameters.Add("@P_ValidTo", obj.ValidTo);
                return SqlData.dataContext.Execute("TokenBucket_Save_Generate", objParameters, commandType: CommandType.StoredProcedure) > 0;
            }
            catch (Exception ex)
            {
                CLoggerDataAccess.WriteLog(ProjectSource.DataAccessLayer, ELogLevel.ERROR, "ERROR ocurred in Token Operation  while calling GenerateToken Action, Ex.: " + ex.Message);
            }
            return false;

        }
        public TokenBucket GetToken(string Token)
        {
            DynamicParameters objParameters = new DynamicParameters();
            try
            {
                objParameters.Add("@p_Token", Token);
                objParameters.Add("@p_UserName", "");
                return SqlData.dataContext.QueryFirst<TokenBucket>("TOKENBUCKET_READ", objParameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CLoggerDataAccess.WriteLog(ProjectSource.DataAccessLayer, ELogLevel.ERROR, "ERROR ocurred in Token Operation  while calling GetToken Action, Ex.: " + ex.Message);
            }
            return null;
        }

        public Response UpdateUserPassword(UserInfo objUserInfo)
        {
            DynamicParameters objParameter = new DynamicParameters();
            try
            {
                objParameter.Add("@p_Username", objUserInfo.Username);
                objParameter.Add("@p_Password", objUserInfo.Password);
                return SqlData.dataContext.QueryFirst<Response>("USERENTITY_SAVE_CAHNGEPASSWORD", objParameter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CLoggerDataAccess.WriteLog(ProjectSource.DataAccessLayer, ELogLevel.ERROR, "ERROR ocurred in  User Operation  while calling UpdateUserPassword Action, Ex.: " + ex.Message);
            }
            return null;
        }

        public bool ExpireToken(string Token)
        {
            try
            {
                DynamicParameters objParameters = new DynamicParameters();
                objParameters.Add("@p_Token", Token);
                objParameters.Add("@p_Username", "");
                return SqlData.dataContext.Execute("TokenBucket_Save_Expire", objParameters, commandType: CommandType.StoredProcedure) > 0;
            }
            catch (Exception ex)
            {
                CLoggerDataAccess.WriteLog(ProjectSource.DataAccessLayer, ELogLevel.ERROR, "ERROR ocurred in Token Operation  while calling ExpireToken Action, Ex.: " + ex.Message);
            }
            return false;
        }
    }

}
