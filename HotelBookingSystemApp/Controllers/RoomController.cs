using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using HotelBookingSystemApp.Models;
using HotelBookingSystemApp.ViewModels;
using HotelBookingSystemApp.Controllers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace HotelBookingSystemApp.Controllers
{
    public class RoomController : Controller
    {
        private readonly WdaContext db;
        private readonly ILogger<HomeController> _logger;

        public RoomController(WdaContext db, ILogger<HomeController> logger)
        {
            _logger = logger;
            this.db = db;
        }


        public IActionResult Listing(HomeFiltersViewModel filters)
        {
            if (!ModelState.IsValid)
                throw new ApplicationException("Invalid filters");

            var results = db.Room.Include(room => room.RoomType).AsQueryable();
            if (!string.IsNullOrEmpty(filters.City))
                results = results.Where(room => room.City == filters.City);
            if (filters.RoomTypeId != null)
                results = results.Where(room => room.RoomTypeId == filters.RoomTypeId);
            if (filters.CountOfGuests != null)
                results = results.Where(room => room.CountOfGuests == filters.CountOfGuests);
            if (filters.AmountMin != null)
                results = results.Where(room => room.Price >= filters.AmountMin);
            if (filters.AmountMax != null)
                results = results.Where(room => room.Price <= filters.AmountMax);

            if (!string.IsNullOrEmpty(filters.CheckInDate) && !string.IsNullOrEmpty(filters.CheckOutDate) && filters.CheckInDate.CompareTo(filters.CheckOutDate) <= 0)
            {
                // Find all bookings in date range
                // Dates are stored in the database in the format: yyyy-mm-dd
                // So to compare, we compare them as strings
                var bookings = db.Bookings.Where(booking =>
                    booking.CheckInDate.CompareTo(filters.CheckOutDate) <= 0 &&
                    filters.CheckInDate.CompareTo(booking.CheckOutDate) <= 0);

                // Return all rooms except the ones contained in the bookings collection
                results = results.Where(i => !bookings.Any(b => b.RoomId == i.RoomId));
            }

            var model = new ListingPageViewModel();
            model.Rooms = results;
            model.Filters = filters;

            // Get all cities and store in ViewData
            ViewData["Cities"] = db.Room.Select(room => room.City).Distinct();
            // Get all room types and store in ViewData
            ViewData["RoomTypes"] = db.RoomType;

            return View(model);
        }

        [HttpGet]
        public IActionResult Detail(int id, BookingViewModel bookingInfo)
        {
            var room = db.Room.SingleOrDefault(r => r.RoomId == id);
            if (room == null)
                return RedirectToAction("Index", "Home");

            var model = new ReviewsViewModel
            {
                Room = room,
                BookingInfo = bookingInfo,

                ShowBookingButton = !string.IsNullOrEmpty(bookingInfo.CheckInDate) && !string.IsNullOrEmpty(bookingInfo.CheckOutDate)
            };
            model.BookingInfo.RoomId = id;

            // Find all bookings in date range
            // Dates are stored in the database in the format: yyyy-mm-dd
            // So to compare, we compare them as strings
            var bookings = db.Bookings.Where(booking =>
                booking.CheckInDate.CompareTo(bookingInfo.CheckOutDate) <= 0 &&
                bookingInfo.CheckInDate.CompareTo(booking.CheckOutDate) <= 0 &&
                booking.RoomId == id);

            model.IsAvailable = !bookings.Any();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult SubmitBooking(BookingViewModel bookingInfo)
        {

            db.Bookings.Add(new Bookings

            {
                CheckInDate = bookingInfo.CheckInDate,
                CheckOutDate = bookingInfo.CheckOutDate,
                DateCreated = DateTime.Now,
                RoomId = bookingInfo.RoomId,
                UserId = ((User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier).Value.ToString().Replace("-", ""))});
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}