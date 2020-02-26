using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ANBCNews.Model.User
{
    public class UserInfo
    {
        public long UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }

        public string Email { get; set; }
        public string ProfileImage { get; set; }
        [JsonIgnore]
        public bool? IsActive { get; set; }
        public string Token { get; set; }

    }
    public class ResetPassword
    {
        public string OldPassword { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PasswordMD5 { get; set; }

    }
}
