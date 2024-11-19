using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSamples.Data
{
    public class CustomNorthwindContext : NorthwindContext
    {
        public DbSet<ProductModel> ProductModels { get; set; }
        public CustomNorthwindContext()
        {

        }

        public CustomNorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.Name).HasColumnName("ProducName");
                entity.Property(e => e.Price).HasColumnName("UnitPrice");
            });
        }
    }
}
