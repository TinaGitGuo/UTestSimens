namespace WebMVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RouteContact")]
    public partial class RouteContact
    {
        public Guid Id { get; set; }

        public Guid RouteId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        public bool IsTop { get; set; }

        [StringLength(20)]
        public string Post { get; set; }

        public virtual Route Route { get; set; }
    }
}
