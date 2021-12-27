﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelBookingSystemApp.Models
{
    public partial class Bookings
    {
        public int BookingId { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
    }
}
