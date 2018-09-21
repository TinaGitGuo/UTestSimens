namespace WebMVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Roles = new HashSet<Role>();
            Roles1 = new HashSet<Role>();
            RoleMenus = new HashSet<RoleMenu>();
            RoleMenus1 = new HashSet<RoleMenu>();
            Routes = new HashSet<Route>();
            Routes1 = new HashSet<Route>();
            RouteChecks = new HashSet<RouteCheck>();
            UserRoles = new HashSet<UserRole>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public int UserType { get; set; }

        [StringLength(50)]
        public string OpenId { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public bool IsTop { get; set; }

        [StringLength(20)]
        public string Post { get; set; }

        public DateTime? EditTime { get; set; }

        public Guid? Editor { get; set; }

        public bool IsDisable { get; set; }

        public DateTime CreateTime { get; set; }

        public Guid Creator { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Role> Roles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Role> Roles1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoleMenu> RoleMenus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoleMenu> RoleMenus1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Route> Routes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Route> Routes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RouteCheck> RouteChecks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
