using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.App_Code
{
    [AttributeUsage(AttributeTargets.Property |
                    AttributeTargets.Field, AllowMultiple = false)]
    public sealed class LocRequired  :  ValidationAttribute,IClientValidatable
    {/// <summary>Gets or sets a value that indicates whether an empty string is allowed.</summary>
     /// <returns>true if an empty string is allowed; otherwise, false. The default value is false.</returns>

        public bool AllowEmptyStrings
        {
            
            get;
            
            set;
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.RequiredAttribute" /> class.</summary>
        
        //public RequiredAttribute()
        //    : base(() => DataAnnotationsResources.RequiredAttribute_ValidationError)
        //{
        //}

        /// <summary>Checks that the value of the required data field is not empty.</summary>
        /// <returns>true if validation is successful; otherwise, false.</returns>
        /// <param name="value">The data field value to validate.</param>
        /// <exception cref="T:System.ComponentModel.DataAnnotations.ValidationException">The data field value was null.</exception>
        
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            string text = value as string;
            if (text != null && !this.AllowEmptyStrings)
            {
                return text.Trim().Length != 0;
            }
            return true;
        }
        public LocRequired()
            : base(() => "{0} field validation failed.")
        {
        }
       
        //public override string FormatErrorMessage(string name)
        //{
        //    return String.Format(CultureInfo.CurrentCulture,
        //        ErrorMessageString, name);
        //}
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            return new[] { new ModelClientValidationRule { ErrorMessage = "<Your error message>", ValidationType = "locrequired" } };
        }
    }
}