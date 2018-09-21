namespace WebMVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoleMenu")]
    public partial class RoleMenu
    {
        public Guid Id { get; set; }

        public Guid RoleId { get; set; }

        public Guid MenuId { get; set; }

        public DateTime? EditTime { get; set; }

        public Guid? Editor { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedTime { get; set; }

        public DateTime CreateTime { get; set; }

        public Guid Creator { get; set; }

        public virtual Menu Menu { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
