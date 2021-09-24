namespace WcfMovie
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [Table("Movie")]
    [DataContract]
    public partial class Movie
    {
        [DataMember]
        public int MovieId { get; set; }

        [Required]
        [StringLength(100)]
        [DataMember]
        public string Title { get; set; }

        [Column(TypeName = "date")]
        [DataMember]
        public DateTime ReleaseDate { get; set; }

        [DataMember]
        public int RunningTime { get; set; }

        [DataMember]
        public int GenreId { get; set; }

        [Column(TypeName = "money")]
        [DataMember]
        public decimal BoxOffice { get; set; }

        [DataMember]
        public virtual Genre Genre { get; set; }
    }
}
