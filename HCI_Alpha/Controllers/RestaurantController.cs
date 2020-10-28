using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HCI_Alpha.Models;
using HCI_Alpha.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HCI_Alpha.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantRepository _restaurantRepo;

        public RestaurantController(IRestaurantRepository restaurantRepo)
        {
            _restaurantRepo = restaurantRepo;
        }

        public IActionResult CreateRestaurant()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRestaurant(restaurants resturant)
        {
            if (ModelState.IsValid)
            {
                _restaurantRepo.Create(resturant);

                return RedirectToAction("Index");

            }
            return View(resturant);
        }
    }
}
