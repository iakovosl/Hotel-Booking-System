using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using HotelBookingSystemApp.Controllers;
using HotelBookingSystemApp.Models;
using HotelBookingSystemApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HotelBookingSystemApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly WdaContext db;
        private readonly ILogger<HomeController> _logger;

        public ProfileController(WdaContext db, ILogger<HomeController> logger)
        {
            _logger = logger;
            this.db = db;
        }


        [HttpGet]
        public ActionResult Index(ListingPageViewModel model)
        {

            string UserId = ((User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier).Value.ToString().Replace("-", ""));
            var reviews = db.Reviews.Include(x => x.Room).Where(t => t.UserId == UserId).ToList();
            var bookings = db.Bookings.Include(x => x.Room).Where(t => t.UserId == UserId).ToList();
            var favorites = db.Favorites.Include(x => x.Room).Where(t => t.UserId == UserId).ToList();
            model = new ListingPageViewModel();
            model.Reviews = reviews;
            model.Bookings = bookings;
            model.Favorites = favorites;
            return View("Index", model);
        }

        public ActionResult BookingView(ListingPageViewModel model)
        {
            string UserId = ((User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier).Value.ToString().Replace("-", ""));
            var bookings = db.Bookings.Include(x => x.Room).Where(t => t.UserId == UserId).ToList();
            model = new ListingPageViewModel();
            model.Bookings = bookings;
            return PartialView("_BookingView", model);
        }
    }
}
