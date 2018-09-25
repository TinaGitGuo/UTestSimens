namespace EfModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SiemensHP : DbContext
    {
        public SiemensHP()
            : base("name=SiemensHP")
        {
//#if DEBUG
//            this.Database.Connection.ConnectionString = "data source=172.16.98.164;initial catalog=Siemens_Hp;persist security info=True;user id=sa;password=Admin123456;MultipleActiveResultSets=True;App=EntityFramework";
//#else
//                this.Database.Connection.ConnectionString = "data source=172.16.98.164;initial catalog=Siemens_Hp;persist security info=True;user id=sa;password=Admin123456;MultipleActiveResultSets=True;App=EntityFramework";
//#endif


        }

        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleMenu> RoleMenus { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<RouteCheck> RouteChecks { get; set; }
        //public virtual DbSet<RouteContact> RouteContacts { get; set; }
     
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>()
                .HasMany(e => e.RoleMenus)
                .WithRequired(e => e.Menu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.RoleMenus)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Route>()
                .HasMany(e => e.RouteChecks)
                .WithRequired(e => e.Route)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Route>()
                .HasRequired(e => e.Creator).WithMany(a => a.CreatorRoutes).WillCascadeOnDelete(false);
            modelBuilder.Entity<Route>()
                .HasOptional(e => e.Editor).WithMany(a => a.EditorRoutes).WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasRequired(e => e.Creator).WithMany(a => a.CreatorRoles).WillCascadeOnDelete(false);
            modelBuilder.Entity<Role>()
                .HasOptional(e => e.Editor).WithMany(a => a.EditorRoles).WillCascadeOnDelete(false);

            modelBuilder.Entity<RouteCheck>()
                .HasRequired(e => e.Editor).WithMany(a => a.CreatorRouteChecks).WillCascadeOnDelete(false);

            modelBuilder.Entity<RouteCheck>()
                .HasOptional(e => e.Editor).WithMany(a => a.EditorRouteChecks).WillCascadeOnDelete(false);



            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
