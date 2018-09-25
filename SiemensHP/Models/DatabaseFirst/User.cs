using System.Net.Http;
using System.Runtime.Remoting;
using System.Web.Mvc;
using EfModel.App_GlobalResources;
using SiemensHP.Models.DatabaseFirst;


namespace EfModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User: UserEntityBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            CreatorRoles = new HashSet<Role>();
            EditorRoles = new HashSet<Role>();

            RoleMenus = new HashSet<RoleMenu>();
          
            CreatorRoutes = new HashSet<Route>();
            EditorRoutes = new HashSet<Route>();

           CreatorRouteChecks   = new HashSet<RouteCheck>();
            EditorRouteChecks = new HashSet<RouteCheck>();

            UserRoles = new HashSet<UserRole>();
        } 

        [Required(ErrorMessageResourceType = typeof(Siemens3i), ErrorMessageResourceName = "Input_Name")]
        [StringLength(20, ErrorMessageResourceType = typeof(Siemens3i), ErrorMessageResourceName = "CheckLengthName20")]
        [Remote("IsUniqueName", "Remote", HttpMethod = "POST", AdditionalFields = "OpenId,Id", ErrorMessageResourceName = "CheckUniqueName", ErrorMessageResourceType = typeof(Siemens3i))]
        [Display(ResourceType = typeof(Siemens3i), Name = "Name")]
        public string Name { get; set; }
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string Password { get; set; }

        public int UserType { get; set; }
        [StringLength(50)]
        public string OpenId { get; set; }
        [Display(ResourceType = typeof(Siemens3i), Name = "Phone")]
        [Required(ErrorMessageResourceType = typeof(Siemens3i), ErrorMessageResourceName = "Input_Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(13[0-9]|14[579]|15[0-3,5-9]|16[6]|17[0135678]|18[0-9]|19[89])\d{8}$",  ErrorMessageResourceType = typeof(Siemens3i),ErrorMessageResourceName = "CheckPhoneFormat")]
  
        public string Phone { get; set; }
        [Required(ErrorMessageResourceType = typeof(Siemens3i), ErrorMessageResourceName = "Input_Email")]
        [EmailAddress(  ErrorMessageResourceName = "CheckEmailFormat", ErrorMessageResourceType = typeof(Siemens3i))]
        [StringLength(50, ErrorMessageResourceType = typeof(Siemens3i), ErrorMessageResourceName = "邮箱长度不超过50")]
        [Remote("IsUnique", "Remote",   HttpMethod = "POST", AdditionalFields = "OpenId,Id", ErrorMessageResourceName = "CheckUniqueEmail", ErrorMessageResourceType = typeof(Siemens3i))]
        [Display(ResourceType = typeof(Siemens3i), Name = "Email")]
        public string Email { get; set; }

        [Display(ResourceType = typeof(Siemens3i), Name = "IsTop")]
        public bool IsTop { get; set; }
        [Display(ResourceType = typeof(Siemens3i), Name = "Post")]
        [StringLength(20)]
        public string Post { get; set; }
 
        [Display(Name = "禁用")]
        public bool IsDisable { get; set; }

        //[InverseProperty("CreatorUser")]
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Role> CreatorRoles { get; set; }
        //[InverseProperty("EditorUser")]
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Role> EditorRoles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoleMenu> RoleMenus { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Route> Routes { get; set; }
        //[InverseProperty("CreatorUser")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Route> CreatorRoutes { get; set; }
        //[InverseProperty("EditorUser")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Route> EditorRoutes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RouteCheck> CreatorRouteChecks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RouteCheck> EditorRouteChecks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
