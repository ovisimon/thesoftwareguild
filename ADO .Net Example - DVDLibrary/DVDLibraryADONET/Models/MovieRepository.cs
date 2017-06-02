using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

namespace DVDLibraryADONET.Models
{
    public class MovieRepository : IMovieRepository
    {
        public List<Movie> GetAll()
        {
            List<Movie> movies = new List<Movie>();

            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * From DVDTable";

                cmd.Connection = conn;
                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Movie m = new Movie();

                        m.DVDID = (int)dr["DVDID"];
                        m.Title = dr["Title"].ToString();
                        m.ReleaseDate = dr["ReleaseDate"].ToString();
                        m.Director = dr["Director"].ToString();
                        m.Rating = dr["Rating"].ToString();
                        m.Notes = dr["Notes"].ToString();
                        movies.Add(m);
                    }
                }
            }
            return movies;
        }

        public IEnumerable<Movie> GetSpecific(string category, string term)
        {
            if(category == "title")
            {
                var movies = GetAll().Where(m => m.Title == term);
                return movies;
            }
            if(category == "director")
            {
                var movies = GetAll().Where(m => m.Director == term);
                return movies;
            }
            if(category == "rating")
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

        public Movie GetById(int id)
        {
            var m = GetAll().FirstOrDefault(x => x.DVDID == id);
            return m;
        }

        public void AddDVD(Movie movie)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                        ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO DVDTABLE (Title, ReleaseDate, Director, Rating, Notes) " +
                    "VALUES (@Title, @ReleaseDate, @Director, @Rating, @Notes)";

                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);
                cmd.Parameters.AddWithValue("@Director", movie.Director);
                cmd.Parameters.AddWithValue("@Rating", movie.Rating);
                cmd.Parameters.AddWithValue("@Notes", movie.Notes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditDVD(Movie movie)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                        ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Update DVDTABLE Set Title = @Title, ReleaseDate = @ReleaseDate, Director = @Director, Rating = @Rating, Notes = @Notes Where DVDID = @DVDID";

                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);
                cmd.Parameters.AddWithValue("@Director", movie.Director);
                cmd.Parameters.AddWithValue("@Rating", movie.Rating);
                cmd.Parameters.AddWithValue("@DVDID", movie.DVDID);
                cmd.Parameters.AddWithValue("@Notes", movie.Notes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteDVD(int dvdid)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                        ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Delete from DVDTable Where DVDID = @dvdid";

                cmd.Parameters.AddWithValue("@DVDID", dvdid);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}