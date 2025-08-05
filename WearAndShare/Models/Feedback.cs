using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WearAndShare.Models
{
    [Table("Feedback")]
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Người gửi")]
        public string FromUserName { get; set; }
        [Display(Name = "Người nhận")]
        public string ToUserName { get; set; }

        = string.Empty;

        [Display(Name = "Nội dung")]
        public string Message { get; set; }
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Ngày gửi")]
        public DateTime SendDate { get; set; } = DateTime.Now;
        public int? Ref {  get; set; }
    }
}