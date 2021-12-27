﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelBookingSystemApp.Models
{
    public partial class Reviews
    {
        public int ReviewId { get; set; }
        public int Rate { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
    }
}
