using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DVDLibraryADONET.Models
{
    public class DapperMovieRepository : IMovieRepository
    {
        public void AddDVD(Movie movie)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                            .ConnectionStrings["DVDLibrary"]
                            .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@Title", movie.Title);
                parameters.Add("@ReleaseDate", movie.ReleaseDate);
                parameters.Add("@Director", movie.Director);
                parameters.Add("@Rating", movie.Rating);
                parameters.Add("@Notes", movie.Notes);

                cn.Execute("AddDVD",
                    parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteDVD(int dvdid)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                            .ConnectionStrings["DVDLibrary"]
                            .ConnectionString;
                
                var parameters = new DynamicParameters();
                parameters.Add("@DVDID", dvdid);

                cn.Execute("DeleteDVD",
                    parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void EditDVD(Movie movie)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                            .ConnectionStrings["DVDLibrary"]
                            .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@DVDID", movie.DVDID);
                parameters.Add("@Title", movie.Title);
                parameters.Add("@ReleaseDate", movie.ReleaseDate);
                parameters.Add("@Director", movie.Director);
                parameters.Add("@Rating", movie.Rating);
                parameters.Add("@Notes", movie.Notes);

                cn.Execute("EditDVD",
                    parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Movie> GetAll()
        {
            {
                using (var cn = new SqlConnection())
                {
                    cn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["DVDLibrary"]
                        .ConnectionString;

                    return cn.Query<Movie>("GetAll",
                        commandType: CommandType.Text).ToList();
                }
            }
        }

        public Movie GetById(int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                            .ConnectionStrings["DVDLibrary"]
                            .ConnectionString;
                
                var parameters = new DynamicParameters();
                parameters.Add("@DVDID", id);

                return cn.Query<Movie>(
                    "GetByID",
                    parameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
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