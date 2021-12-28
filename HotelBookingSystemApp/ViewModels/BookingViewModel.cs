using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBookingSystemApp.Models;

namespace HotelBookingSystemApp.ViewModels
{
    public class BookingViewModel
    {
        public int RoomId { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public Reviews Reviews { get; set; }
        public Favorites Favorites { get; set; }

    }
}
