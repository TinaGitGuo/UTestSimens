namespace WebMVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Role()
        {
            RoleMenus = new HashSet<RoleMenu>();
            UserRoles = new HashSet<UserRole>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public DateTime? EditTime { get; set; }

        public Guid? Editor { get; set; }

        public DateTime CreateTime { get; set; }

        public Guid Creator { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoleMenu> RoleMenus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
