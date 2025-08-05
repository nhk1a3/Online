namespace WearAndShare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InvoinceDetail")]
    public partial class InvoinceDetail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string invoinceNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int productId { get; set; }

        public int? quanlityProduct { get; set; }

        public int? unitPrice { get; set; }

        public int? totalPrice { get; set; }

        public int? totalDiscount { get; set; }

        public virtual Invoince Invoince { get; set; }

        public virtual Product Product { get; set; }
    }
}
