using MovieRentalManagementSystem_V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieRepository movieRepository = new MovieRepository();

            while (true)
            {

                Console.WriteLine("Movie Rental System");
                Console.WriteLine("1. Add a Movie");
                Console.WriteLine("2. View All Movies");
                Console.WriteLine("3. Update a Movie");
                Console.WriteLine("4. Delete a Movie");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {

                    case 1:
                        Console.WriteLine("enter the id:");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter the title");
                        string title = Console.ReadLine();
                        Console.WriteLine("director");
                        string director = Console.ReadLine();
                        Console.WriteLine("enter the price");
                        decimal price = decimal.Parse(Console.ReadLine());              
                        movieRepository.createMovie();
                        break;
                    case 2:
                        movieRepository.ReadMovie();

                        break;
                    case 3:
                        Console.WriteLine("enter the id:");
                        int updateid = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter the title");
                        string newtitle = Console.ReadLine();
                        Console.WriteLine("director");
                        string newdirector = Console.ReadLine();
                        Console.WriteLine("enter the price");
                        decimal newprice = decimal.Parse(Console.ReadLine());
                        movieRepository.ValidateMovieRentalPrice(newprice);

                        Movie updatemovie = new Movie(updateid, newtitle, newdirector, newprice);
                        movieRepository.UpdateMovie(updatemovie);
                        break;


                    case 4:
                        Console.WriteLine("\t\tremove movie");

                        Console.WriteLine("enter the id:");
                        int deleteid = int.Parse(Console.ReadLine());
                        //movieManager.DeleteMovie(deleteid);
                        movieRepository.DeleteMovie(deleteid);
                        break;
                    case 5:
                        Environment.Exit(0);

                        break;
                    default:
                        Console.WriteLine("invaild input");
                        Console.Clear();
                        break;

                }
                Console.WriteLine();
            }
        }
    
    }
}
