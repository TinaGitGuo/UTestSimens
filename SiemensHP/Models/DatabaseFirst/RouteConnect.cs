namespace EfModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using EfModel.App_GlobalResources;
    [Table("RouteContact")]
    public partial class RouteContact
    {
        public Guid Id { get; set; }

        public Guid RouteId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Siemens3i), ErrorMessageResourceName = "Input_Name")]
        [StringLength(20, ErrorMessage = "{0}长度不大于{1}")]
        [Display(ResourceType = typeof(Siemens3i), Name = "Name")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Siemens3i), Name = "Phone")]
        [Required(ErrorMessageResourceType = typeof(Siemens3i), ErrorMessageResourceName = "Input_Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(13[0-9]|14[579]|15[0-3,5-9]|16[6]|17[0135678]|18[0-9]|19[89])\d{8}$", ErrorMessage = "请检查您的手机号")]
        [StringLength(20, ErrorMessage = "{0}长度不大于{1}")]
        [Index(IsUnique = true)]
        public string Phone { get; set; }


        [Display(ResourceType = typeof(Siemens3i), Name = "IsTop")]
        public bool IsTop { get; set; }

        [Display(ResourceType = typeof(Siemens3i), Name = "Post")]
        [StringLength(20)]
        [Required(ErrorMessageResourceType = typeof(Siemens3i), ErrorMessageResourceName = "Input_Post")]
        public string Post { get; set; }

        public virtual Route Route { get; set; }
    }
}
