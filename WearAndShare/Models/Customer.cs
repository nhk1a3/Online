namespace WearAndShare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Invoinces = new HashSet<Invoince>();
        }

        public int customerId { get; set; }

        [StringLength(250)]
        public string firstName { get; set; }

        [Required]
        [StringLength(250)]
        public string lastName { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        [StringLength(250)]
        public string address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoince> Invoinces { get; set; }
    }
}
