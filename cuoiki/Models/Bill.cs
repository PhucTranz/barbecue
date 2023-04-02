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
        [Key]
        public int idBill { get; set; }

        public int? idAcc { get; set; }

        public int? idStatus { get; set; }

        [StringLength(100)]
        public string total { get; set; }

        [StringLength(100)]
        public string meta { get; set; }

        public bool? hide { get; set; }

        public virtual Account Account { get; set; }

        public virtual Statuss Statuss { get; set; }

        public virtual DetailBill DetailBill { get; set; }
    }
}
