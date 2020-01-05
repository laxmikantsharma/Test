using System;
using System.Collections.Generic;
using System.Text;

namespace ANBCNews.Model
{
    public class DBResponse
    {
        public DBResponse()
        {
            Result = false;
            Message = string.Empty;
        }
        public long ID { get; set; }
        public int Action { get; set; }
        public string Other { get; set; }
        public string Message { get; set; }
        public bool Result { get; set; }
    }
}
