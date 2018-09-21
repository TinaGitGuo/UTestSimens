using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Resources;

namespace WebMVC.Common
{
    public class LLRequiredAttribute:RequiredAttribute
    {
        public LLRequiredAttribute()
        {
            this.ErrorMessageResourceType = typeof(DataAnnotationsResources);
            this.ErrorMessageResourceName = "RequiredAttribute_ValidationError";
        }
    }
}