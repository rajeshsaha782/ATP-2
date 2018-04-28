using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Infrastructure
{
    public class easylifeDbContext : DbContext
    {
        public easylifeDbContext():base("easylifeDBContext")
        {
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Delivery_Man> Delivery_Mans { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_Review> Product_Reviews { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Search_History> Search_Historys { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Dislike> Dislikes { get; set; }
        
    }
}
