using EFCodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieCatalogCodeFirst otherctx = new MovieCatalogCodeFirst();

            var allMovies = otherctx.Movies.Where(x => x.Title == "The Lion King");

            allMovies.ForEach(x => Console.WriteLine(x.Title));

            Console.ReadKey();
        }
    }
}
