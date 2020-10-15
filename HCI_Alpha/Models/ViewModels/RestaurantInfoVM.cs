using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCI_Alpha.Models
{
    public class RestaurantInfoVM
    {
        public int Rest_Id { get; set; }
        public int Rest_COVID_Id { get; set; }
        public string Rest_Name { get; set; }
        public string Rest_Address { get; set; }
        public string Rest_City { get; set; }
        public string Rest_ZipCode { get; set; }
        public string Rest_State { get; set; }
        public string Rest_Phone { get; set; }
        public string Rest_Cuisine { get; set; }
        public string Rest_CovidPolicy { get; set; }
        public int Rest_PriceRange { get; set; }
        public string Rest_Time { get; set; }
        public int Rest_TakeOut { get; set; }
        public int Rest_CurbSide { get; set; }
        public int Rest_Delivery { get; set; }
        public int Rest_IndoorSeating { get; set; }
        public int Rest_LimitedSeating { get; set; }
        public string Rest_Menu { get; set; }
    }
}
