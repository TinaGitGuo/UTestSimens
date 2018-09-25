using SiemensHP.Models.DatabaseFirst;

namespace EfModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoleMenu")]
    public partial class RoleMenu: IdBase
    {
        public Guid RoleId { get; set; }

        public Guid MenuId { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Menu Menu { get; set; }

        public virtual Role Role { get; set; }
    }
}
