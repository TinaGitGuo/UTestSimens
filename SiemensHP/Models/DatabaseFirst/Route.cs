

using System.ComponentModel;
using System.Dynamic;

using EfModel.App_GlobalResources;


namespace EfModel
{
    using EfModel;
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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Siemens3i), ErrorMessageResourceName = "Input_Destination")]
   
        [StringLength(50,ErrorMessageResourceType = typeof(Siemens3i),ErrorMessageResourceName = "目的地50")]
        [Display(ResourceType = typeof(Siemens3i), Name = "Destination", Order = -1, Prompt = "Input_Destination")]
        public string Destination { get; set; }
        [Required(ErrorMessageResourceType = typeof(Siemens3i), ErrorMessageResourceName = "Input_FromDate")]
        [Display(ResourceType = typeof(Siemens3i), Name = "FromDate"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime FromDate { get; set; }
        [Required(ErrorMessageResourceType = typeof(Siemens3i), ErrorMessageResourceName = "Input_EndDate")]
        [DataType(DataType.DateTime)]
        [Display(ResourceType = typeof(Siemens3i), Name = "EndDate", Order = 3), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(ResourceType = typeof(Siemens3i), Name = "Days")]
        public int Days { get; set; }

        [Required(ErrorMessageResourceType = typeof(Siemens3i), ErrorMessageResourceName = "Input_RouteDescription")]
        [StringLength(200, ErrorMessageResourceType = typeof(Siemens3i), ErrorMessageResourceName = "目的200")]
        [Display(ResourceType = typeof(Siemens3i), Name = "RouteDescription")]
        public string RouteDescription { get; set; }
        [Required(ErrorMessageResourceType = typeof(Siemens3i), ErrorMessageResourceName = "Input_FirstContact")]
        [StringLength(20, ErrorMessageResourceType = typeof(Siemens3i), ErrorMessageResourceName = "第一联系人20")]
        [Display(ResourceType = typeof(Siemens3i), Name = "FirstContact")]
        public string FirstContact { get; set; }


        [StringLength(200, ErrorMessageResourceType = typeof(Siemens3i), ErrorMessageResourceName = "接机安排200")]
        [Display(ResourceType = typeof(Siemens3i), Name = "PlaneArrange")]
        public string PlaneArrage { get; set; }


        [Display(ResourceType = typeof(Siemens3i), Name = "IsAirport")]
        public bool IsAirport { get; set; }


        [Display(ResourceType = typeof(Siemens3i), Name = "IsScreen")]
        public bool IsScreen { get; set; }
        [StringLength(200, ErrorMessageResourceType = typeof(Siemens3i), ErrorMessageResourceName = "工厂车间访问长度不超过200")]
        [Display(ResourceType = typeof(Siemens3i), Name = "Factory")]
        public string Factory { get; set; }
        [StringLength(20)]
        [Display(ResourceType = typeof(Siemens3i), Name = "Repast")]
        public string Repast { get; set; }
        [Display(ResourceType = typeof(Siemens3i), Name = "Allergy")]
        [StringLength(20)]
        public string Allergy { get; set; }

        [Required(ErrorMessageResourceType = typeof(Siemens3i), ErrorMessageResourceName = "Input_CompanyName")]
        [Display(ResourceType = typeof(Siemens3i), Name = "CompanyName")]
        [StringLength(50, ErrorMessageResourceType = typeof(Siemens3i), ErrorMessageResourceName = "公司长度不超过50")]
        public string CompanyName { get; set; }
        [Display(ResourceType = typeof(Siemens3i), Name = "AllergyRemark")]
        [StringLength(200, ErrorMessageResourceType = typeof(Siemens3i), ErrorMessageResourceName = "其他过敏项长度不超过200")]
        public string AllergyRemark { get; set; }
        [Display(Name= "状态")]
        [Required]
        public int Status { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EditTime { get; set; }

        public Guid? Editor { get; set; }
        [Display(Name = "提交时间"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true) ]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateTime { get; set; } = DateTime.Now;
        [Display(Name = "提交人")]
        public Guid Creator { get; set; }





        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RouteCheck> RouteChecks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RouteContact> RouteContacts { get; set; }
    }


    public partial class Route
    {

        public void ResetCheckBoxValue()
        {
            foreach (var repast in Repast + Allergy)
            {
                int i = int.Parse(repast.ToString());
                switch (i)
                {
                    case (int)DietEnum.Muslim:
                        Muslim = true; break;
                    case (int)DietEnum.Vegetarian:
                        Vegetarian = true; break;
                    case (int)DietEnum.NoRedMeat:
                        NoRedMeat = true; break;

                    case (int)AllergyEnum.Green_bean:
                        Green_bean = true; break;
                    case (int)AllergyEnum.Seafood:
                        Seafood = true; break;
                }
            }
        }
        public void ResetRepastFromCheckBoxValue()
        {
            this.Repast = string.Empty;
            Repast = Muslim ? ((int)DietEnum.Muslim).ToString() : string.Empty;
            Repast += Vegetarian ? ((int)DietEnum.Vegetarian).ToString() : string.Empty;
            Repast += NoRedMeat ? ((int)DietEnum.NoRedMeat).ToString() : string.Empty;

            this.Allergy = string.Empty;
            Allergy = Green_bean ? ((int)AllergyEnum.Green_bean).ToString() : string.Empty;
            Allergy += Seafood ? ((int)AllergyEnum.Seafood).ToString() : string.Empty;
        }
        [NotMapped]
        public bool Muslim { get; set; }
        [NotMapped]
        public bool Vegetarian { get; set; }
        [NotMapped]
        public bool NoRedMeat { get; set; }
        [NotMapped]
        public bool Green_bean { get; set; }
        [NotMapped]
        public bool Seafood { get; set; }
        public enum DietEnum
        {
            [Description("穆斯林")]
            Muslim = 1,
            [Description("素食")]
            Vegetarian = 2,
            [Description("不吃红肉")]
            NoRedMeat = 3
        }
        public enum AllergyEnum
        {
            [Description("青豆")]
            Green_bean = 4,
            [Description("海鲜")]
            Seafood = 5
        }
    }


}
