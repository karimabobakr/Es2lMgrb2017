namespace Es2LMegrb_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Review
    {
        public long ReviewID { get; set; }

        public string ReviewText { get; set; }

        public DateTime? ReviewDateTime { get; set; }

        public int? DestinationRate { get; set; }

        public bool? UserLike { get; set; }

        public long? User_ID { get; set; }

        public long? Destination_ID { get; set; }

        public virtual Destinatione Destinatione { get; set; }

        public virtual User User { get; set; }
    }
}
