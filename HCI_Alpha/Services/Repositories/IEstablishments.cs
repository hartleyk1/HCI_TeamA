using HCI_Alpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCI_Alpha.Services.Repositories
{
    public interface IEstablishments
    {
        ICollection<restaurants> ReadAll();
        ICollection<cuisines> ReadAllTypes();
        ICollection<reviews> ReadAllReviewsByRestaurant(int id);
        restaurants ReadReastaurantById(int id);
    }
}
