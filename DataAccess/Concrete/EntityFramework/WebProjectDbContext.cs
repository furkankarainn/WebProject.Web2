using Core.Entities;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class WebProjectDbContext :DbContext
    {
        public WebProjectDbContext()
        {
            
        }
        public WebProjectDbContext(DbContextOptions options):base(options) 
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=KuyumcuDb;Integrated Security=True;MultipleActiveResultSets=true");
                optionsBuilder.UseSqlServer(@"");
            }

        }
        public DbSet<Piece> Pieces{ get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPiece> ProductPieces { get; set; }
        public DbSet<Menu> Menus  { get; set; }
        public DbSet<OrderHeader> OrderHeaders  { get; set; }
        public DbSet<OrderDetail> OrderDetails  { get; set; }
        public DbSet<Customer> Customers  { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims  { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
