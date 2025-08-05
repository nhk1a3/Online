namespace WearAndShare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            InvoinceDetails = new HashSet<InvoinceDetail>();
        }

        public int productId { get; set; }

        [Required]
        [StringLength(250)]
        public string productName { get; set; }

        [StringLength(2000)]
        public string image { get; set; }

        public int? price { get; set; }

        public int? discount { get; set; }

        [StringLength(2000)]
        public string description { get; set; }

        public int? quanlity { get; set; }

        [StringLength(250)]
        public string brand { get; set; }

        public DateTime? dateCreate { get; set; }

        public bool? status { get; set; }

        [Display(Name = "Là hàng ký gửi")]
        public bool IsHangKyGui { get; set; } = false;
        [Display(Name = "Tên người gửi")]
        public string TenNguoiGui { get; set; }
        [Display(Name ="Phương thức chiết khấu")]
        public int PhuongThucChietKhau { get; set; } // 0 - Phần trăm, 1 - Tiền mặt
        [Display(Name ="Giá trị chiết khấu")]
        public decimal GiaTriChietKhau { get; set; }

        [Display(Name ="Số điện thoại người gửi")]
        public string SoDTNguoiGui { get; set; }
        public int categoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string userName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoinceDetail> InvoinceDetails { get; set; }

        public virtual Member Member { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
