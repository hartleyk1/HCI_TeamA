using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HCI_Alpha.Models
{
    public class restaurants
    {
        public int id { get; set; }
        public int city_id { get; set; }
        public int cuisine_id { get; set; }

        [DisplayName("Cuisine")]
        public string cuisines { get; set; }
        [DisplayName("Currency")]
        public string currency { get; set; }
        [DisplayName("Type of Establishment")]
        public string establishment { get; set; }
        [DisplayName("Delivery?")]
        public int has_delivery { get; set; }
        [DisplayName("Take Out?")]
        public int has_takeaway { get; set; }
        [DisplayName("Street Name")]
        public string address { get; set;}
        [DisplayName("City")]
        public string city { get; set; }
        [DisplayName("State")]
        public string state_code { get; set; }
        [DisplayName("City")]
        public string locality { get; set; }
        public string locality_verbose { get; set; }
        [DisplayName("Zip Code")]
        public string zip_code { get; set; }
        [DisplayName("Menu URL")]
        public string menu_url { get; set; }
        [DisplayName("Name of Restaurant")]
        public string name { get; set; }
        [DisplayName("Telephone")]
        public string telephone { get; set; }
        [DisplayName("Price Range")]
        public int price_range { get; set; }
        [DisplayName("Hours of Operation")]
        public string timings { get; set; }
        [DisplayName("Official Website")]
        public string url { get; set; }
        public string aggregate_rating { get; set; }
        public string rating_text { get; set; }
       
    }
}
