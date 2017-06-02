using System.Collections.Generic;

namespace DVDLibraryADONET.Models
{
    public interface IMovieRepository
    {
        void AddDVD(Movie movie);
        void DeleteDVD(int dvdid);
        void EditDVD(Movie movie);
        List<Movie> GetAll();
        Movie GetById(int id);
        IEnumerable<Movie> GetSpecific(string category, string term);
    }
}