namespace WearAndShare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Member")]
    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            Articles = new HashSet<Article>();
            Invoinces = new HashSet<Invoince>();
            Products = new HashSet<Product>();
        }

        [Key]
        [StringLength(50)]
        public string userName { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [StringLength(250)]
        public string firstName { get; set; }

        [StringLength(250)]
        public string lastName { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthday { get; set; }

        [StringLength(20)]
        public string identityNumber { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        public DateTime? dateOfJoin { get; set; }

        [StringLength(250)]
        public string address { get; set; }

        [StringLength(2000)]
        public string avatar { get; set; }

        public bool? status { get; set; }

        public int roleId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Article> Articles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoince> Invoinces { get; set; }

        public virtual Role Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
