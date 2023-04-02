namespace cuoiki.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Statuss")]
    public partial class Statuss
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Statuss()
        {
            Bill = new HashSet<Bill>();
        }

        [Key]
        public int idStatus { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? timeBegin { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? timeFinish { get; set; }

        [StringLength(100)]
        public string statusDone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bill { get; set; }
    }
}
