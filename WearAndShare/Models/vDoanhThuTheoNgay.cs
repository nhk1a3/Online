namespace WearAndShare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vDoanhThuTheoNgay")]
    public partial class vDoanhThuTheoNgay
    {
        [Key]
        [StringLength(10)]
        public string dateOrder { get; set; }

        public int? income { get; set; }
    }
}
