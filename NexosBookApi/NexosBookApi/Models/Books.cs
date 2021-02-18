namespace NexosBookApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Books
    {
        [Key]
        public long Id_Boock { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public DateTime? CreationDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Gender { get; set; }

        [StringLength(50)]
        public string NumPages { get; set; }

        public long Id_Editorial { get; set; }

        public long Id_Author { get; set; }

        public virtual Books Books1 { get; set; }

        public virtual Books Books2 { get; set; }
    }
}
