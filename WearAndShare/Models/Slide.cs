namespace WearAndShare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        public int id { get; set; }

        public DateTime? dateCreate { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(250)]
        public string description { get; set; }

        [StringLength(50)]
        public string url { get; set; }

        public bool? status { get; set; }
    }
}
