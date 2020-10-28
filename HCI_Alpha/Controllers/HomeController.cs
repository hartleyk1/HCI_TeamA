/* ***************************************************************
 *  
 *  Class: CSCI-4927-940
 *  Team: Team A
 *  Created: 20201010
 *  Last Modified: 20201011
 *  Purpose: Display the list of restauraunts availalbe to the user
 * 
 * ***************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HCI_Alpha.Models;
using HCI_Alpha.Services.Repositories;
using HCI_Alpha.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Internal;

namespace HCI_Alpha.Controllers
{
    public class HomeController : Controller
    {
        #region Injections
        private readonly ILogger<HomeController> _logger;
        private readonly IEstablishments _goEats;
        private readonly RestaurantsDbContext _db;
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        public HomeController(ILogger<HomeController> logger, IEstablishments goEats, RestaurantsDbContext db)
        {
            _logger = logger;
            _goEats = goEats;
            _db = db;
        }
        #endregion

        /// <summary>
        /// Display all of the restaurants based on the provided parameters
        /// </summary>
        /// <param name="sort">Obtain the type of sorting</param>
        /// <param name="cuisineType">Obtainthe cuisine type</param>
        /// <param name="searchWord">Obtain the word that the user wants to search</param>
        /// <returns></returns>
        public IActionResult Index(int ?sort, string cuisineType, string searchWord, string serviceType)
        {
            // Bypass parameters if necessary, using character x
            if (cuisineType == "x") cuisineType = "";
            if (searchWord == "x") searchWord = "";
            if (serviceType == "x") serviceType = "";
            else if (!string.IsNullOrEmpty(cuisineType) && cuisineType != "undefined")
                ViewBag.Message = "You are viewing " + cuisineType + " cuisine . . .";
            // Obtain the filtering sort
            ViewBag.Sort = sort;
            // Obtain cuisines as a list
            ViewData["Cuisine"] = _goEats.ReadAllTypes();
            var restList = (from p in _db.Restaurants
                            join f in _db.Covid19
                            on p.id equals f.restaurant_id into ThisList
                            from f in ThisList.DefaultIfEmpty()
                            select new
                            {
                                Id = p.id,
                                CID = f.id,
                                Name = p.name,
                                Address = p.address,
                                City = p.city,
                                State = p.state_code,
                                ZipCode = p.zip_code,
                                Phone = p.telephone,
                                CovidPolicy = f.comments,
                                Covid_I = f.indoor_dining,
                                Covid_L = f.limit_seating,
                                Covid_T = f.take_out,
                                Covid_C = f.curbside,
                                Food = p.cuisines,
                                Delivery = p.has_delivery,
                                TakeOut = p.has_takeaway,
                                PriceRange = p.price_range,
                                Time = p.timings,
                                Menu = p.menu_url
                            }).ToList()
                       .Select(x => new RestaurantInfoVM()
                       {
                           Rest_Id = x.Id,
                           Rest_COVID_Id = x.CID,
                           Rest_Name = x.Name,
                           Rest_Address = x.Address,
                           Rest_City = x.City,
                           Rest_State = x.State,
                           Rest_ZipCode = x.ZipCode,
                           Rest_Phone = x.Phone,
                           Rest_CurbSide = x.Covid_C,
                           Rest_Delivery = x.Delivery,
                           Rest_IndoorSeating = x.Covid_I,
                           Rest_LimitedSeating = x.Covid_L,
                           Rest_TakeOut = x.Covid_T,
                           Rest_CovidPolicy = x.CovidPolicy,
                           Rest_PriceRange = x.PriceRange,
                           Rest_Time = x.Time,
                           Rest_Cuisine = x.Food,
                           Rest_Menu = x.Menu
                       });
            // Adjust results via parameters 
            if(!string.IsNullOrEmpty(searchWord))
                return View(restList.Where(x => x.Rest_Name.Contains(searchWord.ToString())).OrderByDescending(x => x.Rest_Name));
            if (!string.IsNullOrEmpty(cuisineType) && sort == 0)
                return View(restList.Where(x => x.Rest_Cuisine.Contains(cuisineType.ToString())).OrderByDescending(x => x.Rest_Name));
            else if(!string.IsNullOrEmpty(cuisineType) && sort == 1)
                return View(restList.Where(x => x.Rest_Cuisine.Contains(cuisineType.ToString())).OrderBy(x => x.Rest_Name));
            else if (string.IsNullOrEmpty(cuisineType) && sort == 0)
                return View(restList.OrderByDescending(x => x.Rest_Name));
            else if(string.IsNullOrEmpty(cuisineType) && sort ==1)
                return View(restList.OrderBy(x => x.Rest_Name));
            else
                return View(restList);
        }


        /// <summary>
        /// Display privacy policies
        /// </summary>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Display reviews based on restaurant's identifier to the user
        /// </summary>
        /// <param name="id">Obtain restaurant's unique identifier</param>
        /// <returns>Returns a list of reviews</returns>
        public IActionResult Reviews(int id)
        {
            ViewData["RestInfo"] = _goEats.ReadReastaurantById(id);
            var reviews = _goEats.ReadAllReviewsByRestaurant(id);
            return View(reviews);
        }



        /// <summary>
        /// Display information about the project
        /// </summary>
        public IActionResult About()
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
