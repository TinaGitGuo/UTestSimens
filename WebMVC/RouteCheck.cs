namespace WebMVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RouteCheck")]
    public partial class RouteCheck
    {
        public Guid Id { get; set; }

        public Guid RouteId { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        public DateTime CreateTime { get; set; }

        public Guid Creator { get; set; }

        public virtual Route Route { get; set; }

        public virtual User User { get; set; }
    }
}
