using System;
using HotelBookingSystemApp.Models;

namespace HotelBookingSystemApp.ViewModels
{
    public class ReviewsViewModel
    {
        public virtual Room Room { get; set; }
        public virtual Reviews Reviews { get; set; }
        public BookingViewModel BookingInfo { get; set; }
        public bool ShowBookingButton { get; set; }
        public bool IsAvailable { get; set; }
        public int RoomId { get; set; }
    }
}