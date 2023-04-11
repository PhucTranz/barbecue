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

        public virtual DbSet<About> About { get; set; }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<DetailBill> DetailBill { get; set; }
        public virtual DbSet<DetailCart> DetailCart { get; set; }
        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<Footer> Footer { get; set; }
        public virtual DbSet<MenuBar> MenuBar { get; set; }
        public virtual DbSet<SlidesShow> SlidesShow { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TypeFood> TypeFood { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banner>()
                .Property(e => e.meta)
                .IsUnicode(false);

            modelBuilder.Entity<Bill>()
                .HasMany(e => e.DetailBill)
                .WithRequired(e => e.Bill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cart>()
                .HasMany(e => e.DetailCart)
                .WithRequired(e => e.Cart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Food>()
                .Property(e => e.meta)
                .IsUnicode(false);

            modelBuilder.Entity<Food>()
                .HasMany(e => e.DetailBill)
                .WithRequired(e => e.Food)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Food>()
                .HasMany(e => e.DetailCart)
                .WithRequired(e => e.Food)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Footer>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Footer>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<MenuBar>()
                .Property(e => e.meta)
                .IsUnicode(false);

            modelBuilder.Entity<SlidesShow>()
                .Property(e => e.meta)
                .IsUnicode(false);

            modelBuilder.Entity<TypeFood>()
                .Property(e => e.meta)
                .IsUnicode(false);
        }
    }
}
