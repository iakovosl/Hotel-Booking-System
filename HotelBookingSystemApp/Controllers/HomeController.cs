using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HotelBookingSystemApp.Models;

namespace HotelBookingSystemApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WdaContext db;

        public HomeController(ILogger<HomeController> logger, WdaContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            // Get all cities and store in ViewData
            ViewData["Cities"] = db.Room.Select(room => room.City).Distinct();
            // Get all room types and store in ViewData
            ViewData["RoomTypes"] = db.RoomType;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
