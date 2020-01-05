using System;
using System.Collections.Generic;
using System.Text;

namespace ANBCNews.Utility
{
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
