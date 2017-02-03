namespace Es2LMegrb_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Reviews = new HashSet<Review>();
        }

        public long UserID { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        [StringLength(20)]
        public string UserPassword { get; set; }

        [StringLength(20)]
        public string UserPhone { get; set; }

        public string UserAddress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
