using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class MyEcommerceDb: DbContext
    {
        // Create all DbSets for all models
        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }

        public DbSet<StoreModel> Stores { get; set; }


        // Create Constructors
        public MyEcommerceDb() { }
        public MyEcommerceDb(DbContextOptions options): base(options) {}

        // Override OnConfiguring()
        protected override void OnConfiguring(DbContextOptionsBuilder options) 
        {
            // Check if options have already been configured in the testing suite.
            //if (!options.IsConfigured)
            //{
            //    options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MyEcommerceDb;Trusted_Connection=True;");
            //}
        }
    }
}
