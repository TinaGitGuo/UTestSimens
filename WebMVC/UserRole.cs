namespace WebMVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserRole")]
    public partial class UserRole
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }
    }
}
