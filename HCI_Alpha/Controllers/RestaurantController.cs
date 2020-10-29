using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HCI_Alpha.Models;
using HCI_Alpha.Services.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace HCI_Alpha.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantRepository _restaurantRepo;
        private readonly IEstablishments _establishmentRepo;

        public RestaurantController(IRestaurantRepository restaurantRepo, IEstablishments establishmentRepo)
        {
            _restaurantRepo = restaurantRepo;
            _establishmentRepo = establishmentRepo;
        }

        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {
            var getRest = _restaurantRepo.Read(id);

            if(getRest != null)
            {
                return View(getRest);
            }

            return RedirectToAction("Index", "Home" );
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(restaurants rest)
        {
            var check = _restaurantRepo.Read(rest.id);

            if(check != null)
            {
                _restaurantRepo.Update(rest);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            var check = _restaurantRepo.Read(id);

            if(check != null)
            {
                return View(check);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteRest(int id)
        {
            var getRest = _restaurantRepo.Read(id);

            if(getRest != null)
            {
                _restaurantRepo.Delete(id);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");

        }

        public IActionResult CreateRestaurant()
        {
            List<cities> cityList = new List<cities>();
            List<cuisines> cuisineList = new List<cuisines>();
            cityList = _establishmentRepo.ReadAllCities();
            cuisineList = _establishmentRepo.ReadAllCuisines();
            cityList.Insert(0, new cities { id = 0, city_name = "-- Select City --"});
            ViewBag.ListOfCities = cityList;
            ViewBag.ListOfCuisines = cuisineList;
            return View();
        }

        [HttpPost]
        public IActionResult CreateRestaurant(restaurants restaurant)
        {
            if (restaurant.has_delivery != 0 && restaurant.has_delivery != 0 && restaurant.establishment != "0")
            {
                _restaurantRepo.Create(restaurant);

                return RedirectToAction("Index", "Home");
            }
            return View(restaurant);
        }

        public IActionResult CreateReview(int restaurantId)
        {
            var restaurant = _restaurantRepo.Read(restaurantId);
            ViewData["RestInfo"] = restaurant;
            reviews review = new reviews()
            {
                restaurant_id = restaurantId
            };
            return View();
        }

        [HttpPost]
        public IActionResult CreateReview(reviews review)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(review.rating_text) && (!string.IsNullOrEmpty(review.rating.ToString()) || review.rating > 0))
            {
                review.review_time_friendly = DateTime.Now.ToString("MMM dd, yyyy");
                if (string.IsNullOrEmpty(review.customer_name))
                {
                    review.customer_name = "Anonymous Reviewer";
                }
                _restaurantRepo.CreateReview(review);
                return RedirectToAction("Reviews", "Home", new { id = review.restaurant_id });
            } else
            {
                ModelState.AddModelError(string.Empty, "Your Review is missing the required fields. Please try again and ensure that all fields are filled out correctly.");
            }
            var restaurant = _restaurantRepo.Read(review.restaurant_id);
            ViewData["RestInfo"] = restaurant;
            return View(review);
        }
    }
}
