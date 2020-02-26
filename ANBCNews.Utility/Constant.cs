using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace ANBCNews.Utility
{
    public static class Constants
    {
        public static class Strings
        {
            public static class JwtClaimIdentifiers
            {
                public const string Rol = "rol", Id = "id";
            }

            public static class JwtClaims
            {
                public const string ApiAccess = "api_access";
            }
        }
        public static string GetMD5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
                System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();
                for (int i = 0; i < (data.Length); i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
        public static bool MailSend(List<string> MailTo, string MailFrom, string Subject, string Message, List<string> CC = null, List<string> BCC = null, Dictionary<string, string> SubjectVariables = null, Dictionary<string, string> BodyVariables = null, bool IsBodyHtml = true, bool defaultSignature = true)
        {
            MailMessage mailMessage = new MailMessage();
            StringBuilder msgBody = new StringBuilder(Message);
            StringBuilder msgSubject = new StringBuilder(Subject);

            mailMessage.From = new MailAddress(MailFrom);
            mailMessage.Sender = new MailAddress(MailFrom);
            mailMessage.ReplyToList.Add(MailFrom);
            mailMessage.IsBodyHtml = IsBodyHtml;
            mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            if (BodyVariables != null)
            {
                foreach (var item in BodyVariables)
                {
                    msgBody = msgBody.Replace("[%" + item.Key + "%]", item.Value);
                }
            }
            mailMessage.Body = msgBody.ToString();

            if (SubjectVariables != null)
            {
                foreach (var item in SubjectVariables)
                {
                    msgSubject = msgSubject.Replace("[%" + item.Key + "%]", item.Value);
                }
            }
            mailMessage.Subject = msgSubject.ToString();

            if (MailTo != null)
            {
                foreach (string address in MailTo)
                {
                    foreach (string add in address.Split(new char[] { ';', ',' }))
                    {
                            mailMessage.To.Add(add.Trim());
                    }
                }
            }
            if (CC != null)
            {
                foreach (string address in CC)
                {
                    foreach (string add in address.Split(new char[] { ';', ',' }))
                    {
                            mailMessage.CC.Add(add.Trim());
                    }
                }
            }
            if (BCC != null)
            {
                foreach (string address in BCC)
                {
                    foreach (string add in address.Split(new char[] { ';', ',' }))
                    {
                            mailMessage.Bcc.Add(add.Trim());
                    }
                }
            }
            if (String.IsNullOrWhiteSpace(MailConfiguration.Host))
            {
                return false;
            }
            if (mailMessage == null)
            {
                return false;
            }
            System.Net.NetworkCredential credential;

            credential = new NetworkCredential(MailConfiguration.UserName, MailConfiguration.Password);

            SmtpClient client = new SmtpClient();
            client.Host = MailConfiguration.Host;
            client.Credentials = credential;
            client.Port = MailConfiguration.Port;
            client.EnableSsl = MailConfiguration.EnableSsl;

            try
            {
                if (mailMessage.From == null)
                    mailMessage.From = new MailAddress(MailConfiguration.UserName);
                client.Send(mailMessage);
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
    }
    public static class MailConfiguration
    {
        public static string Host { get; set; }
        public static int Port { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static bool EnableSsl { get; set; }
        public static string SystemBCC { get; set; }
        public static string MailSignature { get; set; }

        public static void ResetValues()
        {
            // Here you want to reset to the old initialized value
            Host = null;
            Port = 0;
            UserName = null;
            Password = null;
            EnableSsl = false;
            SystemBCC = null;
            MailSignature = null;
        }
    }
    public enum TemplateCode
    {
        [EnumMember]
        [Description("User Activativation")]
        USERCREATE,

        [EnumMember]
        [Description("Forget Password")]
        FORGETPASSWORD,

        [EnumMember]
        [Description("User Registration")]
        USERREGISTRATION,

        [EnumMember]
        [Description("Email Invite Friends")]
        EMAILINVITEFRIEND,

        [EnumMember]
        [Description("SMS Invite Friends")]
        TEXTINVITEFRIEND,

        [EnumMember]
        [Description("User OTP")]
        USEROTP,
    }
    public enum ELogLevel
    {
        DEBUG = 1,
        ERROR,
        FATAL,
        INFO,
        WARN
    }
    public enum ProjectSource
    {
        WebApi,
        DataAccessLayer,
        BusinessLayer
    }

}
