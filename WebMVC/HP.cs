namespace WebMVC
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HP : DbContext
    {
        public HP()
            : base("name=HP")
        {
        }

        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleMenu> RoleMenus { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<RouteCheck> RouteChecks { get; set; }
        public virtual DbSet<RouteContact> RouteContacts { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
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
                .HasMany(e => e.RouteContacts)
                .WithRequired(e => e.Route)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.Editor);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.Creator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.RoleMenus)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Creator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.RoleMenus1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.Editor);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Routes)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Creator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Routes1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.Editor);

            modelBuilder.Entity<User>()
                .HasMany(e => e.RouteChecks)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Creator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
