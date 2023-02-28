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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idFooter { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(1000)]
        public string intro { get; set; }

        [StringLength(1000)]
        public string address { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(100)]
        public string sdt { get; set; }

        [StringLength(100)]
        public string meta { get; set; }

        public bool? hide { get; set; }

        public int? order { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? datebegin { get; set; }
    }
}
