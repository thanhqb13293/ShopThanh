using Microsoft.AspNet.Identity.EntityFramework;
using ShopThanh.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopThanh.Data
{
    public class ShopThanhDbContext: IdentityDbContext<ApplicationUser>
    {
        public ShopThanhDbContext():base("ShopThanhConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Footer> Footers { set; get; }
        public DbSet<Menu> Menus { set; get; }
        public DbSet<MenuGroup> MenuGroups{ set; get; }
        public DbSet<Order> Orders{ set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        public DbSet<Page> Pages { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<PostCategory> PostCategories { set; get; }
        public DbSet<PostTag> PostTags { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<ProductCategory> ProductCategories { set; get; }
        public DbSet<ProductTag> ProductTags { set; get; }
        public DbSet<Slide> Slides { set; get; }
        public DbSet<SupportOnline> SupportOnlines { set; get; }
        public DbSet<SystemConfig> SystemConfigs { set; get; }
        public DbSet<Tag> Tags { set; get; }
        public DbSet<VisistorStatistic> VisistorStatistics { set; get; }
        public DbSet<Error> Errors { get; set; }

        public static ShopThanhDbContext Create()
        {
            return new ShopThanhDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole>().HasKey(n => new { n.UserId,n.RoleId });
            modelBuilder.Entity<IdentityUserLogin>().HasKey(n => n.UserId);
        }
    }
}
