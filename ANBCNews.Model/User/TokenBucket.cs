using System;
using System.Collections.Generic;
using System.Text;

namespace ANBCNews.Model.User
{
    public class TokenBucket
    {
        public long ID { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public bool IsUsed { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
