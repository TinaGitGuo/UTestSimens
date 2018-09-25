using SiemensHP.Models.DatabaseFirst;

namespace EfModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RouteCheck")]
    public partial class RouteCheck:EntityBase
    {
        public Guid RouteId { get; set; }
        [StringLength(200)]
        public string Remark { get; set; }
        public virtual Route Route { get; set; }
    }
}
