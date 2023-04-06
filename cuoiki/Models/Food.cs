namespace cuoiki.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Food")]
    public partial class Food
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Food()
        {
            DetailBills = new HashSet<DetailBill>();
            DetailCarts = new HashSet<DetailCart>();
        }

        [Key]
        public int idFood { get; set; }

        public int? idTypeFood { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        public int? price { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(100)]
        public string meta { get; set; }

        public bool? hide { get; set; }

        public string img { get; set; }

        public DateTime? datebegin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailBill> DetailBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailCart> DetailCarts { get; set; }

        public virtual TypeFood TypeFood { get; set; }
    }
}
