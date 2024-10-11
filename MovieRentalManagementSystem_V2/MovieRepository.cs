using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalManagementSystem_V2
{
    public class MovieRepository
    {
        private string connectionstrings = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MovieRentalManagement;Integrated Security=True";

        public void createMovie(Movie movie)
        {
            using (var connect = new SqlConnection(connectionstrings))
            {
                try
                {
                    connect.Open();
                    string quert = "insert into Movies(MovieId,Title,director,rentalprice) values(@movieid,@title,@director,@price)";
                    var command = new SqlCommand(quert, connect);
                    command.Parameters.AddWithValue("@movieid", (movie.MovieId));
                    command.Parameters.AddWithValue("@title", (movie.Title));
                    command.Parameters.AddWithValue("@director", movie.Director);
                    command.Parameters.AddWithValue("@price", movie.RentalPrice);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public List<Movie> ReadMovie()
        {
            List<Movie> movies = new List<Movie>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstrings))
                {
                    connection.Open();
                    string query = "SELECT * FROM Movies";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                movies.Add(new Movie(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetString(3)
                                ));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading movies: {ex.Message}");
            }
            return movies;
        }

        public void UpdateMovie(Movie movie)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstrings))
                {
                    connection.Open();
                    string qu = "UPDATE Movies SET Title = @title,Director=@director,Price =@director WHERE MovieId =@movieid";
                    using (SqlCommand command = new SqlCommand(qu, connection))
                    {
                        command.Parameters.AddWithValue("@movieid", movie.MovieId);
                        command.Parameters.AddWithValue("@title", (movie.Title));
                        command.Parameters.AddWithValue("@director", movie.Director);
                        command.Parameters.AddWithValue("@director", movie.RentalPrice);
                        command.ExecuteNonQuery();
                        Console.WriteLine("Update successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void DeleteMovie(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstrings))
                {
                    connection.Open();
                    string query = "DELETE FROM Movies WHERE MovieId = @movieId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@movieId", id);
                        command.ExecuteNonQuery();
                        Console.WriteLine("delete successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public Movie GetMovieById(int movieId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstrings))
                {
                    connection.Open();
                    string query = "SELECT * FROM Movies WHERE MovieId = @movieId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@movieId", movieId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Movie(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetString(3)
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error movie by ID: {ex.Message}");
            }
            return null;
        }
        public void ValidateMovieRentalPrice(decimal price)
        {
            while (price <= 0)
            {
                Console.WriteLine("Error:price must be possitive,please enter again:");
                price = Convert.ToDecimal(Console.ReadLine());
            }
        }
        public string CapitalizeTilte(string title)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title.ToLower());
        }

    }



}
