using System.Collections.Generic;
using HotelBookingSystemApp.Models;

namespace HotelBookingSystemApp.ViewModels
{
    public class RoomDetailsViewModel
    {
        public RoomDetailsViewModel()
        {
            Reviews = new List<Reviews>();
            Bookings = new List<Bookings>();
        }
        public Room Room { get; set; }

        public List<Reviews> Reviews { get; set; }
        public List<Bookings> Bookings { get; set; }
        public BookingViewModel BookingInfo { get; set; }

        public bool ShowBookingButton { get; set; }
        public bool IsAvailable { get; set; }


    }
}
