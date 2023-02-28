using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace cuoiki.Models
{
    public partial class barbecue : DbContext
    {
        public barbecue()
            : base("name=barbecue")
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<DetailBill> DetailBill { get; set; }
        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<Footer> Footer { get; set; }
        public virtual DbSet<MenuBar> MenuBar { get; set; }
        public virtual DbSet<SlidesShow> SlidesShow { get; set; }
        public virtual DbSet<Statuss> Statuss { get; set; }
        public virtual DbSet<Tablee> Tablee { get; set; }
        public virtual DbSet<TypeFood> TypeFood { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .HasOptional(e => e.DetailBill)
                .WithRequired(e => e.Bill);

            modelBuilder.Entity<TypeFood>()
                .Property(e => e.name)
                .IsUnicode(false);
        }
    }
}
