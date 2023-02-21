using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace cuoiki.Models
{
    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=barbecue_db")
        {
        }

        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<MenuBar> MenuBar { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
