using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;
using Resources;
using WebMVC.App_Code;
using WebMVC.Common;

namespace WebMVC.Models
{
    public class UserwwwMetadata
    {
        public Guid Id { get; set; }
    // [LLRequired]
        public string Name { get; set; }
        [Required(ErrorMessageResourceType = typeof(DataAnnotationsResources),ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
     //  [ AssertThat("StartDate >= JobStart", ErrorMessage = "Time Manager may not begin before job start date")]
        [Range(20,90)]
        public int Age { get; set; }

        public DateTime CreateTime { get; set; }
    }
}