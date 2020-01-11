using System;
using System.Collections.Generic;
using System.Text;

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

        public string Password { get; set; }

        public string Email { get; set; }
        public string ProfileImage { get; set; }

        public bool? IsActive { get; set; }

    }

}
