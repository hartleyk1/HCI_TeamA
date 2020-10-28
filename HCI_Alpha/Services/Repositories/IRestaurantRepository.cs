using HCI_Alpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCI_Alpha.Services.Repositories
{
    public interface IRestaurantRepository
    {
        restaurants Read(int id);
        restaurants Create(restaurants restaurant);
        void Update(int id, restaurants restaurant);
        void Delete(int id);

    }
}
