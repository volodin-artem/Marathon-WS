namespace Marathon.ModelContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Position")]
    public partial class Position
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Position()
        {
            Staff = new HashSet<Staff>();
        }

        public short PositionId { get; set; }

        [StringLength(50)]
        public string PositionName { get; set; }

        [Required]
        [StringLength(1000)]
        public string PositionDescription { get; set; }

        [StringLength(10)]
        public string PayPeriod { get; set; }

        [StringLength(255)]
        public string PayRate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Staff> Staff { get; set; }
    }
}
