using System.Diagnostics;

using Kernal_Travel_Guide.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kernal_Travel_Guide.Controllers
{
    public class HomeController : Controller
    {

        private readonly KernalTravelGuideContext _context;

        public HomeController(KernalTravelGuideContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

		public IActionResult About()
		{
			return View();
		}

		public IActionResult Services()
		{
			return View();
		}

        public IActionResult Hotels()
        {
            return View(_context.Hotels.ToList());
        }

        public IActionResult HotelDetails(int id)
        {

            if (id == null || _context.Hotels == null)
            {
                return NotFound();
            }

            var hotel = _context.Hotels
                .FirstOrDefault(m => m.HotelId == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }
        public IActionResult Packages()
		{
			return View();
		}



        public IActionResult Resorts()
        {
            return View(_context.Resorts.ToList());
        }

        public IActionResult ResortDetails(int id)
        {

            if (id == null || _context.Resorts == null)
            {
                return NotFound();
            }

            var Resort = _context.Resorts
                .FirstOrDefault(m => m.ResortId == id);
            if (Resort == null)
            {
                return NotFound();
            }

            return View(Resorts);
        }






        public IActionResult Restuarnts()
        {
            return View(_context.Restaurants.ToList());
        }

        public IActionResult RestauranttDetails(int id)
        {

            if (id == null || _context.Restaurants == null)
            {
                return NotFound();
            }

            var Restaurant = _context.Restaurants
                .FirstOrDefault(m => m.RestaurantId == id);
            if (Restaurant == null)
            {
                return NotFound();
            }

            return View(Restaurant);
        }





        public IActionResult Resort()
        {
            return View(_context.Resorts.ToList());
        }

        public IActionResult ResortsDetails(int id)
        {

            if (id == null || _context.Resorts == null)
            {
                return NotFound();
            }

            var Resort = _context.Resorts
                .FirstOrDefault(m => m.ResortId == id);
            if (Resort == null)
            {
                return NotFound();
            }

            return View(Resort);
        }




        public IActionResult TouristSpots()
        {
            return View(_context.TouristSpots.ToList());
        }

        public IActionResult TouristSpotDetails(int id)
        {

            if (id == null || _context.TouristSpots == null)
            {
                return NotFound();
            }

            var TouristSpot = _context.TouristSpots
                .FirstOrDefault(m => m.TouristSpotId == id);
            if (TouristSpot == null)
            {
                return NotFound();
            }

            return View(TouristSpots);
        }





        public IActionResult TravelInfo()
        {
            return View(_context.TravelInfos.ToList());
        }

        public IActionResult TravelInfoDetails(int id)
        {

            if (id == null || _context.TravelInfos == null)
            {
                return NotFound();
            }

            var TravelInfo = _context.TravelInfos
                .FirstOrDefault(m => m.TravelInfoId == id);
            if (TravelInfo == null)
            {
                return NotFound();
            }

            return View(TravelInfo);
        }




        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AddReservations()
        {
            return View();
        }



    }

}