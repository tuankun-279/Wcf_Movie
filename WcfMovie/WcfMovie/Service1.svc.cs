using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.Entity;

namespace WcfMovie
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public static Movie_Context db = new Movie_Context();
        public void Add(Movie m)
        {
            Movie movie= new Movie();
            db.Movies.Add(m);
            db.SaveChanges();   
        }

        public void Delete(int Id)
        {
            Movie movie = db.Movies.Find(Id);
            db.Movies.Remove(movie);
        }

        public void Edit(Movie m)
        {
            db.Entry(m).State = EntityState.Modified;
            db.SaveChanges();
        }

        public List<Movie> GetAll()
        {
            List<Movie> listMovie = new List<Movie>();

            var movies = db.Movies.Include(m => m.Genre).ToList();
            foreach (var m in movies)
            {
                Movie movie = new Movie();
                movie.MovieId = m.MovieId;
                movie.Title = m.Title;
                movie.ReleaseDate = m.ReleaseDate;
                movie.RunningTime = m.RunningTime;
                movie.BoxOffice = m.BoxOffice;
                movie.GenreId = m.GenreId;
                listMovie.Add(movie);
            }
            //var listMovie = from b in db.Movies join g in db.Genres on b.GenreId equals g.GenreId select b;
            return listMovie;
        }

        public List<Movie> Search(string Search)
        {
            List<Movie> listMovie = new List<Movie>();

            var movies = db.Movies.Include(m => m.Genre).ToList();
            foreach (var m in movies)
            {
                Movie movie = new Movie();
                movie.MovieId = m.MovieId;
                movie.Title = m.Title;
                movie.ReleaseDate = m.ReleaseDate;
                movie.RunningTime = m.RunningTime;
                movie.BoxOffice = m.BoxOffice;
                movie.GenreId = m.GenreId;
                listMovie.Add(movie);
            }
            if(!string.IsNullOrEmpty(Search))
                listMovie = listMovie.Where(s => s.Title.Contains(Search)).ToList();
            return listMovie;
        }

        public Movie GetById(int Id)
        {
            Movie movie = db.Movies.Find(Id);
            return movie;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        
    }
}
