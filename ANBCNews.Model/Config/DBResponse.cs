using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

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
        public string Message { get; set; }
        public bool Result { get; set; }
        public int Action { get; set; }
        public object obj { get; set; }

    }
    public class APIResponse
    {
        public APIResponse()
        {
            StatusCode = string.Empty;
            StatusMessage = string.Empty;
        }
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; } 
        public object Object { get; set; }
        public IEnumerable<object> Collection { get; set; }
    }
}
