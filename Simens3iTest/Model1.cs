namespace Simens3iTest
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Siemens1Context")
        {
        }

        public virtual DbSet<vw_Proposal> vw_Proposal { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<vw_Proposal>()
                .Property(e => e.No)
                .IsUnicode(false);
        }
    }
}
