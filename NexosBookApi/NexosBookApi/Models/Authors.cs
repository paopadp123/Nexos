namespace NexosBookApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Authors
    {
        [Key]
        public long Id_Author { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime? BirthDate { get; set; }

        [StringLength(50)]
        public string Origin { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
    }
}
