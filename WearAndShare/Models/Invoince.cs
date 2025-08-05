namespace WearAndShare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invoince")]
    public partial class Invoince
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoince()
        {
            InvoinceDetails = new HashSet<InvoinceDetail>();
        }

        [Key]
        [StringLength(50)]
        public string invoinceNo { get; set; }

        public DateTime? dateOrder { get; set; }

        public bool? status { get; set; }

        public bool? deliveryStatus { get; set; }

        public DateTime? deliveryDate { get; set; }

        public int totalMoney { get; set; }

        [StringLength(50)]
        public string userName { get; set; }

        public int? customerId { get; set; }

        public string paymentMethod { get; set; } = "TM";

        public virtual Customer Customer { get; set; }

        public virtual Member Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoinceDetail> InvoinceDetails { get; set; }
    }
}
