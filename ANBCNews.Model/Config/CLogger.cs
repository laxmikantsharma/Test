using System;
using System.Collections.Generic;
using System.Text;

namespace ANBCNews.Model
{
    public class DBLogger
    {
        public virtual int ExceptionID
        {
            get;
            set;
        }
        public virtual string Type
        {
            get;
            set;
        }
        public virtual string Message
        {
            get;
            set;
        }
        public virtual string Source
        {
            get;
            set;
        }
        public virtual DateTime CreateDate
        {
            get;
            set;
        }
        public int TotalRecored { get; set; }
        public string ResolveDescription { get; set; }
        public bool IsResolve { get; set; }
        public long ResolveBy { get; set; }
    }
}
