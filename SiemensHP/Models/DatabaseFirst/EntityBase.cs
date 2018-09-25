using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using EfModel;

namespace SiemensHP.Models.DatabaseFirst
{

    public abstract class EntityBase: UserEntityBase
    {
        public virtual User Creator { get; set; }
        public virtual User Editor { get; set; }
    }
    public abstract class UserEntityBase : CreateBase
    {       
        [Display(Name = "更新时间")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EditTime {
            get { return  DateTime.Now; }
            set { this.EditTime = value; }
        }
        public Guid? EditorId { get; set; }           
    }
    public abstract class CreateBase: IdBase
    {
        [Display(Name = "提交时间"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public Guid CreatorId { get; set; }
    }
    public abstract class IdBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
   
}