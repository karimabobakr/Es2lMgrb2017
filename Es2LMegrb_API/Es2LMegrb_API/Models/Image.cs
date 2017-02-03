namespace Es2LMegrb_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Image
    {
        public long ImageID { get; set; }

        [Column("Image")]
        public string Image1 { get; set; }

        public int? Album_ID { get; set; }

        public virtual Album Album { get; set; }
    }
}
