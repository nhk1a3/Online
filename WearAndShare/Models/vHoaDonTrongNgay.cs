namespace WearAndShare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vHoaDonTrongNgay")]
    public partial class vHoaDonTrongNgay
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string invoinceNo { get; set; }

        public DateTime? dateOrder { get; set; }

        public bool? status { get; set; }

        public bool? deliveryStatus { get; set; }

        public DateTime? deliveryDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalMoney { get; set; }

        [StringLength(50)]
        public string userName { get; set; }

        public int? customerId { get; set; }
    }
}
