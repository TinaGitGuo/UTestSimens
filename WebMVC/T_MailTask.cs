//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebMVC
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_MailTask
    {
        public int MailId { get; set; }
        public string Subject { get; set; }
        public string MailContent { get; set; }
        public string MailAttach { get; set; }
        public string MailTo { get; set; }
        public System.DateTime CreateDate { get; set; }
        public bool HasSent { get; set; }
        public Nullable<System.DateTime> SentDate { get; set; }
    }
}
