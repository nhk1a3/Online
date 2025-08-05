using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WearAndShare.Areas.Admin.ViewModels
{
    public class HangKyGuiVM
    {
        public int productId { get; set; }  
        public decimal ThanhTien { get; set; }
        public int LoaiChietKhau { get; set; }
        public decimal GiaTriChietKhau { get; set; }
        public decimal LoiNhuan {  get; set; }
        public string ProductName { get; internal set; }
    }
}