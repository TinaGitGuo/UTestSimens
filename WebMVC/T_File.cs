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
    
    public partial class T_File
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        public int UserID { get; set; }
        public int DirectoryID { get; set; }
        public Nullable<int> DirectoryTemplateID { get; set; }
    }
}
