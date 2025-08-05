namespace WearAndShare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Article")]
    public partial class Article
    {
        public int articleId { get; set; }

        [Required]
        [StringLength(250)]
        public string title { get; set; }

        [StringLength(2000)]
        public string shortDescription { get; set; }

        [StringLength(2000)]
        public string image { get; set; }

        public DateTime? publicDate { get; set; }

        public string content { get; set; }

        public bool? status { get; set; }

        [Required]
        [StringLength(50)]
        public string userName { get; set; }

        public int categoryId { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        public virtual Member Member { get; set; }
    }
}
