namespace WebMVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Route")]
    public partial class Route
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Route()
        {
            RouteChecks = new HashSet<RouteCheck>();
            RouteContacts = new HashSet<RouteContact>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Destination { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Days { get; set; }

        [StringLength(200)]
        public string RouteDescription { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstContact { get; set; }

        [StringLength(200)]
        public string PlaneArrage { get; set; }

        public bool IsAirport { get; set; }

        public bool IsScreen { get; set; }

        [StringLength(200)]
        public string Factory { get; set; }

        [StringLength(20)]
        public string Repast { get; set; }

        [StringLength(20)]
        public string Allergy { get; set; }

        [StringLength(200)]
        public string AllergyRemark { get; set; }

        public int Status { get; set; }

        public DateTime? EditTime { get; set; }

        public Guid? Editor { get; set; }

        public DateTime CreateTime { get; set; }

        public Guid Creator { get; set; }

        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RouteCheck> RouteChecks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RouteContact> RouteContacts { get; set; }
    }
}
