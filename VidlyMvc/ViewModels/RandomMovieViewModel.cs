using System.Collections.Generic;
using VidlyMvc.Models;

namespace VidlyMvc.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}