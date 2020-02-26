using System;
using System.Collections.Generic;
using System.Text;

namespace ANBCNews.Model
{
    public static class ConfigurationSetting
    {
        public static string ConnectionString { get; set; }
        public static string VideoWebUrl { get; set; }
        public static string ImageWebUrl { get; set; }
        public static string WebAppUrl { get; set; }
    }
    public class SystemSettings
    {

        public int Id { get; set; }
        public string SettingCode { get; set; }
        public string SettingName { get; set; }
        public string SettingValue { get; set; }
        public string SettingValueType { get; set; }
        public string SettingDescription { get; set; }
        public string SettingDependsOn { get; set; }
        public string SettingType { get; set; }
    }
   
}
