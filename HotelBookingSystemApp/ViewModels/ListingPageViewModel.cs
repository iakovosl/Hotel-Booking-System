using HotelBookingSystemApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystemApp.ViewModels
{
    public class ListingPageViewModel
    {
        public ListingPageViewModel()
        {
            Bookings = new List<Bookings>();
            Reviews = new List<Reviews>();
            Favorites = new List<Favorites>();
        }
        public IEnumerable<Room> Rooms { get; set; }
        public List<Bookings> Bookings { get; set; }
        public List<Reviews> Reviews { get; set; }
        public List<Favorites> Favorites { get; set; }

        public HomeFiltersViewModel Filters { get; set; }
    }
}
