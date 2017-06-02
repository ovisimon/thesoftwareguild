namespace EFCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Movie")]
    public partial class Movie
    {
        public int MovieId { get; set; }

        public int? RatingId { get; set; }

        public int GenreId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual Rating Rating { get; set; }
    }
}
