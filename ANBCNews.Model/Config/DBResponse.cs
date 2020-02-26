using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ANBCNews.Model
{
    public class Response
    {
        public Response()
        {
            Result = false;
            Message = string.Empty;
        }
        public long ID { get; set; } 
        public string Message { get; set; }
        public bool Result { get; set; }
        [JsonIgnore]
        public int Action { get; set; }
        public object obj { get; set; }

    }
}
