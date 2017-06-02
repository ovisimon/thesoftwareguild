using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DVDLibraryADONET.Models
{
    public class EFMovieRepository : IMovieRepository
    {
        public void AddDVD(Movie movie)
        {
            using (var ctx = new DVDLibraryEntities())
            {
                var m = new DVDTable { Title = movie.Title, ReleaseDate = movie.ReleaseDate, Director = movie.Director, Rating = movie.Rating, Notes = movie.Notes, DVDID = movie.DVDID };
                ctx.DVDTables.Add(m);
                ctx.SaveChanges();
            }
        }

        public void DeleteDVD(int dvdid)
        {
            using (var ctx = new DVDLibraryEntities())
            {
                var m = ctx.DVDTables.Where(x => x.DVDID == dvdid).FirstOrDefault();
                ctx.DVDTables.Remove(m);
                ctx.SaveChanges();
            }
        }

        public void EditDVD(Movie movie)
        {
            using (var ctx = new DVDLibraryEntities())
            {
                var m = new DVDTable { Title = movie.Title, ReleaseDate = movie.ReleaseDate, Director = movie.Director, Rating = movie.Rating, Notes = movie.Notes, DVDID = movie.DVDID };
                ctx.Entry(m).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public List<Movie> GetAll()
        {
            DVDLibraryEntities ctx = new DVDLibraryEntities();

            var result = ctx.DVDTables.Select(x => new Movie(){ Title = x.Title, ReleaseDate = x.ReleaseDate, Director = x.Director, Rating = x.Rating, DVDID = x.DVDID, Notes = x.Notes  });
            return result.ToList();
        }

        public Movie GetById(int id)
        {
            DVDLibraryEntities ctx = new DVDLibraryEntities();
            Movie m = new Movie();

            var result = from r in ctx.DVDTables where r.DVDID == id select new Movie() {DVDID = r.DVDID, Director = r.Director, Notes = r.Notes, Rating = r.Rating, ReleaseDate = r.ReleaseDate, Title = r.Title };

            return result.FirstOrDefault();
        }

        public IEnumerable<Movie> GetSpecific(string category, string term)
        {
            if (category == "title")
            {
                var movies = GetAll().Where(m => m.Title == term);
                return movies;
            }
            if (category == "director")
            {
                var movies = GetAll().Where(m => m.Director == term);
                return movies;
            }
            if (category == "rating")
            {
                var movies = GetAll().Where(m => m.Rating == term);
                return movies;
            }
            else
            {
                var movies = GetAll().Where(m => m.ReleaseDate == term);
                return movies;
            }
        }
    }
}