using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalManagementSystem_V2
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string RentalPrice { get; set; }

        public Movie(int movieId, string title, string director, string rentalPrice)
        {
            MovieId = movieId;
            Title = title;
            Director = director;
            RentalPrice = rentalPrice;
        }
    }
}
