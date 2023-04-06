namespace cuoiki.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            DetailBills = new HashSet<DetailBill>();
        }

        [Key]
        public int idBill { get; set; }

        public int? idAcc { get; set; }

        public int? total { get; set; }

        public DateTime? timeBegin { get; set; }

        public DateTime? timeFinish { get; set; }

        public bool? status { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailBill> DetailBills { get; set; }
    }
}
