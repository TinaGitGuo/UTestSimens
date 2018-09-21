namespace EfModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RouteCheck")]
    public partial class RouteCheck
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid RouteId { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateTime { get; set; } = System.DateTime.Now;

        public Guid Creator { get; set; }

        public virtual Route Route { get; set; }

        public virtual User User { get; set; }
    }
}
