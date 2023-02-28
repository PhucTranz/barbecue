namespace cuoiki.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MenuBar")]
    public partial class MenuBar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idMenuBar { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        public string link { get; set; }

        [StringLength(100)]
        public string meta { get; set; }

        public bool? hide { get; set; }

        public int? order { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? datebegin { get; set; }
    }
}
