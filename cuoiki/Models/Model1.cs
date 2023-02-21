using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace cuoiki.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=barbecue_DB")
        {
        }

        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<MenuBar> MenuBar { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<slidesShow> slidesShow { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
