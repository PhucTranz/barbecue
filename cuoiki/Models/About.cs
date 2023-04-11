namespace cuoiki.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("About")]
    public partial class About
    {
        public int id { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        [Column(TypeName = "ntext")]
        public string content { get; set; }

        public string img { get; set; }

        public bool? hide { get; set; }

        public DateTime? datebegin { get; set; }
    }
}
