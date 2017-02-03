namespace Es2LMegrb_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class City
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public City()
        {
            Areas = new HashSet<Area>();
        }

        public long CityID { get; set; }

        public string CityNameEn { get; set; }

        public string CityNameAr { get; set; }

        [StringLength(50)]
        public string CityLongitude { get; set; }

        [StringLength(50)]
        public string CityLatitude { get; set; }

        public int? Country_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Area> Areas { get; set; }

        public virtual Country Country { get; set; }
    }
}
