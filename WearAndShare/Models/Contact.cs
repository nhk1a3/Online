namespace WearAndShare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        public int id { get; set; }

        public DateTime? dateContact { get; set; }

        [StringLength(250)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [StringLength(2000)]
        public string message { get; set; }
    }
}
