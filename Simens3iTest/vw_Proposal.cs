namespace Simens3iTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_Proposal
    {
        [Key]
        [Column(Order = 0)]
        public Guid Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string No { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid CompanyId { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string Title { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(500)]
        public string Question { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(2000)]
        public string Suggestion { get; set; }

        [StringLength(100)]
        public string Others { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Status { get; set; }

        public int? Implementation { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool IsTeamIdea { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool IsShared { get; set; }

        public DateTime? EditTime { get; set; }

        public Guid? Editor { get; set; }

        [Key]
        [Column(Order = 9)]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedTime { get; set; }

        [Key]
        [Column(Order = 10)]
        public DateTime CreateTime { get; set; }

        [Key]
        [Column(Order = 11)]
        public Guid Creator { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int YearF { get; set; }

        public int? YearY { get; set; }

        public int? YearJ { get; set; }

        public decimal? IdeaBonus { get; set; }

        public decimal? EVALABonus { get; set; }

        public decimal? TotalBonus { get; set; }

        [StringLength(50)]
        public string Dapartment { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Photo { get; set; }

        [StringLength(50)]
        public string EmployeeCode { get; set; }

        [StringLength(50)]
        public string CompanyName { get; set; }
    }
}
