using HCI_Alpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCI_Alpha.Services.Repositories
{
    public class DbEstablishments : IEstablishments
    {
        private RestaurantsDbContext _db;

        public DbEstablishments(RestaurantsDbContext db)
        {
            _db = db;
        }

        public ICollection<restaurants> ReadAll()
        {
            return _db.Restaurants.ToList();
        }

        public ICollection<reviews> ReadAllReviewsByRestaurant(int id)
        {
            return _db.Reviews.Where(r => r.restaurant_id == id).ToList();
        }

        public ICollection<cuisines> ReadAllTypes()
        {
            return _db.Cuisines.ToList();
        }

        public restaurants ReadReastaurantById(int id)
        {
            return _db.Restaurants.Where(r => r.id == id).SingleOrDefault();
        }
    }
}
