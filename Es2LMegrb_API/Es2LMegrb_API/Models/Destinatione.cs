namespace Es2LMegrb_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Destinatione
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Destinatione()
        {
            OpeningHours = new HashSet<OpeningHour>();
            Reviews = new HashSet<Review>();
            Features = new HashSet<Feature>();
            Days = new HashSet<Day>();
        }

        [Key]
        public long DestinationID { get; set; }

        public string DestinationNameEn { get; set; }

        [Required]
        public string DestinationNameAr { get; set; }

        public string DestinationLongitude { get; set; }

        public string DestinationLatitude { get; set; }

        public string DestinationAddress { get; set; }

        [StringLength(50)]
        public string DestinationPhone { get; set; }

        public float? DestinationRate { get; set; }

        public int? Album_ID { get; set; }

        public int? Section_ID { get; set; }

        public long? Area_ID { get; set; }

        public virtual Album Album { get; set; }

        public virtual Area Area { get; set; }

        public virtual Section Section { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OpeningHour> OpeningHours { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feature> Features { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Day> Days { get; set; }
    }
}
