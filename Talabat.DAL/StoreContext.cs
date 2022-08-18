using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Talabat.DAL.Data.Config;
using Talabat.DAL.Entities;

namespace Talabat.DAL
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options):base(options)
        {

        }

        public DbSet<Product> products { get; set; }

        public DbSet<ProductType> productsType { get; set; }

        public DbSet<ProductBrand> productBrands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.ApplyConfiguration(new ProductConfiguration);

        }




    }
}
