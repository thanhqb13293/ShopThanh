namespace ShopThanh.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopThanh.Data.ShopThanhDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShopThanh.Data.ShopThanhDbContext context)
        {
            CreateProductCategorySample(context);
            //  This method will be called after migrating to the latest version.
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ShopThanhDbContext()));
            //var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ShopThanhDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "Thanhqb132",
            //    Email = "vietthanh.nguyen132@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "NGUYEN Viet Thanh"             
            //};
            //manager.Create(user, "123456");
            //if (!rolemanager.Roles.Any())
            //{
            //    rolemanager.Create(new IdentityRole { Name = "Admin" });
            //    rolemanager.Create(new IdentityRole { Name = "User" });
            //}
            //var AdminUser = manager.FindByEmail("vietthanh.nguyen132@gmail.com");
            //manager.AddToRoles(AdminUser.Id, new string[] { "Admin", "User" });
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

        }
        private void CreateProductCategorySample(ShopThanh.Data.ShopThanhDbContext context)
        {
            if (context.ProductCategories.Count()==0)
            {
                List<ProductCategory> ListCategory = new List<ProductCategory>
                {
                    new ProductCategory {Name="Dien Lanh",Alias="Dien-Lanh",status=true },
                    new ProductCategory {Name="My Pham",Alias="My-Pham",status=true },
                    new ProductCategory {Name="Do Gia Dung",Alias="Meuble",status=true },
                    new ProductCategory {Name="TeleCommande",Alias="Tele-Commande",status=true }
                };
                context.ProductCategories.AddRange(ListCategory);
                context.SaveChanges();
            }
        }
    }
}
