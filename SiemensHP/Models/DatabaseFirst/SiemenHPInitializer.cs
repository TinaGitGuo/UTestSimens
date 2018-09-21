using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfModel
{
    public class SiemenHPInitializer : CreateDatabaseIfNotExists<SiemensHP>
    {
        protected override void Seed(SiemensHP context)
        {


            var users = new List<User>
            {
            new User{Id=new Guid("7240E4CC-44BE-4760-A8A8-06BBE6E441A6"),Name="admin",Password="202CB962AC59075B964B07152D234B70",UserType=1,IsTop=true,IsDisable=false,CreateTime=DateTime.Now,Creator=new Guid("7240E4CC-44BE-4760-A8A8-06BBE6E441A6")},
                new User{Id=new Guid("05860680-FF6C-4C18-A94D-07AA7A7E85C1"),Name="sale",Password="202CB962AC59075B964B07152D234B70",UserType=1,IsTop=true,IsDisable=false,CreateTime=DateTime.Now,Creator=new Guid("7240E4CC-44BE-4760-A8A8-06BBE6E441A6")}
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var roles = new List<Role>
            {
                new Role{Id=new Guid("755EE754-BD56-451C-95FA-235DAFF33933"),Name="Admin",Description="超级管理员",CreateTime=DateTime.Now,Creator=new Guid("7240E4CC-44BE-4760-A8A8-06BBE6E441A6")},
                new Role{Id=new Guid("DB8B4E55-41BA-4155-ADEF-44127440E7F8"),Name="Sale",Description="销售管理员",CreateTime=DateTime.Now,Creator=new Guid("7240E4CC-44BE-4760-A8A8-06BBE6E441A6")}
            };
            roles.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();

            var menus = new List<Menu>
            {
                new Menu{Id=new Guid("376E916E-AA1C-4505-836C-45BE23D92A5C"),Name="用户管理",Code="1",Url="Users/Index",ParentID="0"}
            };
            menus.ForEach(s => context.Menus.Add(s));
            context.SaveChanges();

            var userRoles = new List<UserRole>
            {
                new UserRole{Id=new Guid("16C6EACF-012F-4BEA-B527-58EF9D44B7C5"),UserId=new Guid("7240E4CC-44BE-4760-A8A8-06BBE6E441A6"),RoleId=new Guid("755EE754-BD56-451C-95FA-235DAFF33933")}
            };
            userRoles.ForEach(s => context.UserRoles.Add(s));
            context.SaveChanges();

            var roleMenus = new List<RoleMenu>
            {
                new RoleMenu{Id=new Guid("4CBD3B44-EC12-4B01-A145-6BEB14985A85"),RoleId=new Guid("755EE754-BD56-451C-95FA-235DAFF33933"),MenuId=new Guid("376E916E-AA1C-4505-836C-45BE23D92A5C"),IsDeleted=false,CreateTime=DateTime.Now,Creator=new Guid("7240E4CC-44BE-4760-A8A8-06BBE6E441A6")}
            };
            roleMenus.ForEach(s => context.RoleMenus.Add(s));
            context.SaveChanges();
        }
    }
}
