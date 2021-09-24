namespace WcfMovie
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Movie_Context : DbContext
    {
        public Movie_Context()
            : base("name=Movie_Context")
        {
        }

        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Movies)
                .WithRequired(e => e.Genre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.BoxOffice)
                .HasPrecision(19, 4);
        }
    }
}
