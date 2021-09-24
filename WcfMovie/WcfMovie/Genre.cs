namespace WcfMovie
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [Table("Genre")]
    [DataContract]
    public partial class Genre
    {
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        
        public Genre()
        {
            Movies = new HashSet<Movie>();
        }
        [DataMember]
        public int GenreId { get; set; }

        [Required]
        [StringLength(100)]
        [DataMember]
        public string GenreName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
