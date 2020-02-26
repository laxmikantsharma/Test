using System;
using System.Collections.Generic;
using System.Text;

namespace ANBCNews.Model.Master
{
    public class MasterTemplate
    {
        public int Id { get; set; }
        public int TotalRecored { get; set; }
        public string TemplateType { get; set; }
        public string TemplateSubject { get; set; }
        public string TemplateCode { get; set; }
        public string TemplateName { get; set; }
        public string TemplateDtls { get; set; }
        public string MailFrom { get; set; }
        public string Accessible { get; set; }
    }
}
