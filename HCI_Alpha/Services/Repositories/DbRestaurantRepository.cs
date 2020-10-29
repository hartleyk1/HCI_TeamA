using HCI_Alpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace HCI_Alpha.Services.Repositories
{
    public class DbRestaurantRepository : IRestaurantRepository
    {
        private RestaurantsDbContext _db;

        public DbRestaurantRepository(RestaurantsDbContext db)
        {
            _db = db;
        }

        public restaurants Read(int id)
        {
            return _db.Restaurants.FirstOrDefault(p => p.id == id);
        }

        public List<reviews> ReadReviewsByRestId(int id)
        {
            return _db.Reviews.Where(x => x.restaurant_id == id).ToList();
        }

        public covid19 ReadRestPol(int id)
        {
            return _db.Covid19.FirstOrDefault(x => x.restaurant_id == id);
        }

        public restaurants Create(restaurants restaurant)
        {
            _db.Restaurants.Add(restaurant);
            _db.SaveChanges();
            return restaurant;
        }

        public reviews CreateReview(reviews review)
        {
            _db.Reviews.Add(review);
            _db.SaveChanges();
            return review;
        }

        public void Update(int id, restaurants restaurant)
        {
            restaurants restaurantToUpdate = Read(id);
            restaurantToUpdate.city_id = restaurant.city_id;
            restaurantToUpdate.cuisine_id = restaurant.cuisine_id;
            restaurantToUpdate.cuisines = restaurant.cuisines;
            restaurantToUpdate.currency = restaurant.currency;
            restaurantToUpdate.establishment = restaurant.establishment;
            restaurantToUpdate.has_delivery = restaurant.has_delivery;
            restaurantToUpdate.has_takeaway = restaurant.has_takeaway;
            restaurantToUpdate.address = restaurant.address;
            restaurantToUpdate.city = restaurant.city;
            restaurantToUpdate.state_code = restaurant.state_code;
            restaurantToUpdate.locality = restaurant.locality;
            restaurantToUpdate.locality_verbose = restaurant.locality_verbose;
            restaurantToUpdate.zip_code = restaurant.zip_code;
            restaurantToUpdate.menu_url = restaurant.menu_url;
            restaurantToUpdate.name = restaurant.name;
            restaurantToUpdate.telephone = restaurant.telephone;
            restaurantToUpdate.price_range = restaurant.price_range;
            restaurantToUpdate.timings = restaurant.timings;
            restaurantToUpdate.url = restaurant.url;
            restaurantToUpdate.aggregate_rating = restaurant.aggregate_rating;
            restaurantToUpdate.rating_text = restaurant.rating_text;
            _db.SaveChanges();
        }

        //There is no need to pass an id in when the id is in the restaurants object.
        public void Update(restaurants restaurant)
        {
            restaurants restaurantToUpdate = Read(restaurant.id);
            restaurantToUpdate.city_id = restaurant.city_id;
            restaurantToUpdate.cuisine_id = restaurant.cuisine_id;
            restaurantToUpdate.cuisines = restaurant.cuisines;
            restaurantToUpdate.currency = restaurant.currency;
            restaurantToUpdate.establishment = restaurant.establishment;
            restaurantToUpdate.has_delivery = restaurant.has_delivery;
            restaurantToUpdate.has_takeaway = restaurant.has_takeaway;
            restaurantToUpdate.address = restaurant.address;
            restaurantToUpdate.city = restaurant.city;
            restaurantToUpdate.state_code = restaurant.state_code;
            restaurantToUpdate.locality = restaurant.locality;
            restaurantToUpdate.locality_verbose = restaurant.locality_verbose;
            restaurantToUpdate.zip_code = restaurant.zip_code;
            restaurantToUpdate.menu_url = restaurant.menu_url;
            restaurantToUpdate.name = restaurant.name;
            restaurantToUpdate.telephone = restaurant.telephone;
            restaurantToUpdate.price_range = restaurant.price_range;
            restaurantToUpdate.timings = restaurant.timings;
            restaurantToUpdate.url = restaurant.url;
            restaurantToUpdate.aggregate_rating = restaurant.aggregate_rating;
            restaurantToUpdate.rating_text = restaurant.rating_text;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            restaurants check = Read(id);

            if(check != null)
            {
                List<reviews> reviews = ReadReviewsByRestId(id);
                covid19 covidStuff = ReadRestPol(id);

                _db.Reviews.RemoveRange(reviews);
                _db.Covid19.Remove(covidStuff);
                _db.Restaurants.Remove(check);
                //_db.Remove(check);
                _db.SaveChanges();
            }

        }
    }
}
