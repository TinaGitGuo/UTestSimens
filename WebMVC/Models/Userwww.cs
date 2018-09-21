using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    [MetadataType(typeof(UserwwwMetadata))]
    public partial class Userwww
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime CreateTime { get; set; }
    }
}