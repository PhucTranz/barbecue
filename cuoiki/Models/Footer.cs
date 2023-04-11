namespace cuoiki.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Footer")]
    public partial class Footer
    {
        [Key]
        public int idFooter { get; set; }

        [StringLength(100)]
        public string timeOpen { get; set; }

        [Column(TypeName = "ntext")]
        public string intro { get; set; }

        [StringLength(1000)]
        public string address { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(100)]
        public string sdt { get; set; }

        public bool? hide { get; set; }

        public DateTime? datebegin { get; set; }
    }
}
