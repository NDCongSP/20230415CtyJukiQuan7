//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ATSCADAWebApp.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class alarmlog
    {
        public int Id { get; set; }
        public System.DateTime DateTime { get; set; }
        public string TagName { get; set; }
        public string TagAlias { get; set; }
        public string Value { get; set; }
        public string ErrorName1 { get; set; }
        public string ErrorName2 { get; set; }
        public string ErrorName3 { get; set; }
        public string ErrorName4 { get; set; }
        public string ErrorName5 { get; set; }
        public string Status { get; set; }
        public string Acknowledged { get; set; }
    }
}
