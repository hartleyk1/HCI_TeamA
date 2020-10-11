using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCI_Alpha.Models
{
    public class restaurants
    {
        public int id { get; set; }
        public int city_id { get; set; }
        public int cuisine_id { get; set; }
        public string cuisines { get; set; }
        public string currency { get; set; }
        public string establishment { get; set; }
        public int has_delivery { get; set; }
        public int has_takeaway { get; set; }
        public string address { get; set;}
        public string city { get; set; }
        public string state_code { get; set; }
        public string locality { get; set; }
        public string locality_verbose { get; set; }
        public string zip_code { get; set; }
        public string menu_url { get; set; }
        public string name { get; set; }
        public string telephone { get; set; }
        public int price_range { get; set; }
        public string timings { get; set; }
        public string url { get; set; }
        public string aggregate_rating { get; set; }
        public string rating_text { get; set; }
       
    }
}
