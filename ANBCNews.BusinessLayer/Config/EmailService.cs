using ANBCNews.DataAccessLayer.Config;
using ANBCNews.DataAccessLayer.Master;
using ANBCNews.Model;
using ANBCNews.Model.Master;
using ANBCNews.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANBCNews.BusinessLayer.Config
{
    public class EmailService
    {
        public bool ForgetPassword(string TemplateCode, string EmailId, string FullName, string RootPath, string recoveryToken)
        {
            bool returnValue = false;

            Dictionary<string, string> bodyVaribleUsr = new Dictionary<string, string>();
            try
            {
                bodyVaribleUsr.Add("DomainName", RootPath);
                bodyVaribleUsr.Add("Email", EmailId);
                bodyVaribleUsr.Add("recoveryToken", recoveryToken);
                bodyVaribleUsr.Add("OTP", recoveryToken);
                bodyVaribleUsr.Add("FULLNAME", FullName);

                List<string> objToMail = new List<string>();
                objToMail.Add(EmailId);
                returnValue = SendMail(TemplateCode, objToMail, null, null, null, bodyVaribleUsr, false);
            }
            catch (Exception ex)
            {
                CLogger.WriteLog(ProjectSource.BusinessLayer, ELogLevel.ERROR, "ERROR ocurred in EmailService while calling ForgetPassword Action, Ex.: " + ex.Message);
            }

            return returnValue;
        }
        public bool SendMail(string TemplateCode, List<string> MailTo = null, List<string> MailCC = null, List<string> MailBCC = null, Dictionary<string, string> SubjectVariables = null, Dictionary<string, string> BodyVariables = null, bool defaultSignature = true)
        {

            try
            {
                if (this.SetSmtpSettings())
                {
                    MasterDataAccess objMasterDataAccess = new MasterDataAccess();
                    MasterTemplate objMailTemplate = objMasterDataAccess.GetTemplate(TemplateCode);
                    if (objMailTemplate != null)
                    {
                        Constants.MailSend(MailTo, objMailTemplate.MailFrom, objMailTemplate.TemplateSubject, objMailTemplate.TemplateDtls, MailCC, MailBCC, SubjectVariables, BodyVariables, true, defaultSignature);
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                CLogger.WriteLog(ProjectSource.BusinessLayer, ELogLevel.ERROR, "ERROR ocurred in EmailService while calling SendMail Action, Ex.: " + ex.Message);
            }
            return false;
        }

        private bool SetSmtpSettings()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(MailConfiguration.Host))
                {
                    SystemSettings Smtp;
                    Smtp = MdSystemSettingResult("SMTPENABLE");

                    if (Smtp != null && Convert.ToBoolean(Smtp.SettingValue))
                    {
                        Smtp = MdSystemSettingResult("SMTPURL");
                        if (Smtp != null)
                            MailConfiguration.Host = Smtp.SettingValue;
                        Smtp = MdSystemSettingResult("SMTPPORT");
                        if (Smtp != null)
                            MailConfiguration.Port = Convert.ToInt32(Smtp.SettingValue);
                        Smtp = MdSystemSettingResult("SMTPUSER");
                        if (Smtp != null)
                            MailConfiguration.UserName = Smtp.SettingValue;
                        Smtp = MdSystemSettingResult("SMTPPWD");
                        if (Smtp != null)
                            MailConfiguration.Password = Smtp.SettingValue;
                        Smtp = MdSystemSettingResult("SMTPSSL");
                        if (Smtp != null)
                            MailConfiguration.EnableSsl = Convert.ToBoolean(Smtp.SettingValue);
                        Smtp = MdSystemSettingResult("MAILBCC");
                        if (Smtp != null)
                            MailConfiguration.SystemBCC = Smtp.SettingValue;
                        Smtp = MdSystemSettingResult("MAILSIGN");
                        if (Smtp != null)
                            MailConfiguration.MailSignature = Smtp.SettingValue;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                CLogger.WriteLog(ProjectSource.BusinessLayer, ELogLevel.ERROR, "ERROR ocurred in EmailService while calling SetSmtpSettings Action, Ex.: " + ex.Message);
            }
            return true;
        }
        private SystemSettings MdSystemSettingResult(string SettingCode)
        {
            SettingDataAccess objDataAccess = new SettingDataAccess();
            SystemSettings Smtp = null;
            try
            {
                Smtp = objDataAccess.GetSystemSetting(SettingCode);
            }
            catch (Exception ex)
            {
                CLogger.WriteLog(ProjectSource.BusinessLayer, ELogLevel.ERROR, "ERROR ocurred in EmailService while calling MdSystemSettingResult Action, Ex.: " + ex.Message);
            }
            return Smtp;
        }
    }
}
