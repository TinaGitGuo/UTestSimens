namespace WebMVC
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BomTestFinal : DbContext
    {
        public BomTestFinal()
            : base("name=BomTestFinal")
        {
        }

        public virtual DbSet<T_Directory> T_Directory { get; set; }
        public virtual DbSet<T_MailTask> T_MailTask { get; set; }
        public virtual DbSet<T_MaterielSAP> T_MaterielSAP { get; set; }
        public virtual DbSet<T_ApprovalRecord> T_ApprovalRecord { get; set; }
        public virtual DbSet<T_CntrNo> T_CntrNo { get; set; }
        public virtual DbSet<T_CntrNoTypical> T_CntrNoTypical { get; set; }
        public virtual DbSet<T_CntrNoTypicalLog> T_CntrNoTypicalLog { get; set; }
        public virtual DbSet<T_DirectoryClass> T_DirectoryClass { get; set; }
        public virtual DbSet<T_DirectoryGroup> T_DirectoryGroup { get; set; }
        public virtual DbSet<T_DirectoryTemplate> T_DirectoryTemplate { get; set; }
        public virtual DbSet<T_File> T_File { get; set; }
        public virtual DbSet<T_MasterInfo> T_MasterInfo { get; set; }
        public virtual DbSet<T_MaterielChildren> T_MaterielChildren { get; set; }
        public virtual DbSet<T_MaterielDesign> T_MaterielDesign { get; set; }
        public virtual DbSet<T_Menu> T_Menu { get; set; }
        public virtual DbSet<T_Product> T_Product { get; set; }
        public virtual DbSet<T_ProductContract> T_ProductContract { get; set; }
        public virtual DbSet<T_ProductContractHeader> T_ProductContractHeader { get; set; }
        public virtual DbSet<T_ProductData> T_ProductData { get; set; }
        public virtual DbSet<T_ProductDataLog> T_ProductDataLog { get; set; }
        public virtual DbSet<T_ProductDataLogTemp> T_ProductDataLogTemp { get; set; }
        public virtual DbSet<T_ProductDataPlan> T_ProductDataPlan { get; set; }
        public virtual DbSet<T_ProductDataTemp> T_ProductDataTemp { get; set; }
        public virtual DbSet<T_ProductSeries> T_ProductSeries { get; set; }
        public virtual DbSet<T_ProjectContract> T_ProjectContract { get; set; }
        public virtual DbSet<T_ProjectContractHeader> T_ProjectContractHeader { get; set; }
        public virtual DbSet<T_Role> T_Role { get; set; }
        public virtual DbSet<T_RoleMenu> T_RoleMenu { get; set; }
        public virtual DbSet<T_Semifinished> T_Semifinished { get; set; }
        public virtual DbSet<T_SemifinishedData> T_SemifinishedData { get; set; }
        public virtual DbSet<T_Series> T_Series { get; set; }
        public virtual DbSet<T_System> T_System { get; set; }
        public virtual DbSet<T_SystemInfo> T_SystemInfo { get; set; }
        public virtual DbSet<T_Typical> T_Typical { get; set; }
        public virtual DbSet<T_TypicalData> T_TypicalData { get; set; }
        public virtual DbSet<T_User> T_User { get; set; }
        public virtual DbSet<T_UserDirectoryTemplate> T_UserDirectoryTemplate { get; set; }
        public virtual DbSet<T_UserRole> T_UserRole { get; set; }
        public virtual DbSet<T_VMaterielDesign> T_VMaterielDesign { get; set; }
        public virtual DbSet<V_ProjectContract_MateielDesign> V_ProjectContract_MateielDesign { get; set; }
        public virtual DbSet<View_1> View_1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_MailTask>()
                .Property(e => e.MailTo)
                .IsUnicode(false);

            modelBuilder.Entity<T_MaterielChildren>()
                .Property(e => e.Number)
                .HasPrecision(18, 5);

            modelBuilder.Entity<T_MaterielChildren>()
                .Property(e => e.OrderId)
                .HasPrecision(18, 5);

            modelBuilder.Entity<T_ProductData>()
                .Property(e => e.Number)
                .HasPrecision(18, 5);

            modelBuilder.Entity<T_ProductData>()
                .Property(e => e.IsEnd)
                .HasPrecision(18, 5);

            modelBuilder.Entity<T_ProductDataLog>()
                .Property(e => e.Number)
                .HasPrecision(18, 5);

            modelBuilder.Entity<T_ProductDataLog>()
                .Property(e => e.IsEnd)
                .HasPrecision(18, 5);

            modelBuilder.Entity<T_ProductDataLogTemp>()
                .Property(e => e.Number)
                .HasPrecision(18, 5);

            modelBuilder.Entity<T_ProductDataTemp>()
                .Property(e => e.MENGE)
                .HasPrecision(18, 5);

            modelBuilder.Entity<T_SemifinishedData>()
                .Property(e => e.Number)
                .HasPrecision(18, 5);

            modelBuilder.Entity<T_SemifinishedData>()
                .Property(e => e.OrderId)
                .HasPrecision(18, 5);

            modelBuilder.Entity<T_Series>()
                .Property(e => e.ProductContractID)
                .IsFixedLength();

            modelBuilder.Entity<T_TypicalData>()
                .Property(e => e.Number)
                .HasPrecision(18, 5);

            modelBuilder.Entity<T_TypicalData>()
                .Property(e => e.OrderId)
                .HasPrecision(18, 5);

            modelBuilder.Entity<V_ProjectContract_MateielDesign>()
                .Property(e => e.T_TypicalData_Number)
                .HasPrecision(18, 5);

            modelBuilder.Entity<V_ProjectContract_MateielDesign>()
                .Property(e => e.OrderId)
                .HasPrecision(18, 5);

            modelBuilder.Entity<View_1>()
                .Property(e => e.T_TypicalData_Number)
                .HasPrecision(18, 5);

            modelBuilder.Entity<View_1>()
                .Property(e => e.OrderId)
                .HasPrecision(18, 5);
        }
    }
}
