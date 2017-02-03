namespace Es2LMegrb_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Section
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Section()
        {
            Destinationes = new HashSet<Destinatione>();
        }

        public int SectionID { get; set; }

        [Required]
        public string SectionNameEn { get; set; }

        [Required]
        public string SectionNameAr { get; set; }

        public string SectionIcon { get; set; }

        public int? Category_ID { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Destinatione> Destinationes { get; set; }
    }
}
